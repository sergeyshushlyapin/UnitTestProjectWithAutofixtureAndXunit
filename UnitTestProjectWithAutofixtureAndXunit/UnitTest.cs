using System;
using Ploeh.AutoFixture.Xunit;
using Xunit;

namespace UnitTestProjectWithAutofixtureAndXunit
{
    public class SimpleFixture : IDisposable
    {
        public void Dispose()
        {
        }
    }

    [CollectionDefinition("Collection of greeting tests")]
    public class SimpleCollection : ICollectionFixture<SimpleFixture>
    { }

    [Collection("Collection of greeting tests")]
    public class SimpleFactTests
    {
        private readonly SimpleFixture _fixture;

        public SimpleFactTests(SimpleFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void TestNumberOne()
        {
            var response = 0;
            Assert.Equal(response,0);
        }
    }

    [Collection("Collection of greeting tests")]
    public class SimpleTheoriesTests
    {
        private readonly SimpleFixture _fixture;

        public SimpleTheoriesTests(SimpleFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [AutoData] /* HERE IS THE PROBLEM */ 
        public void TestNumberTwo(int givenValue)
        {
            var response = 0;
            Assert.Equal(givenValue,response);
        }
        /*
         System.InvalidOperationExceptionNo data found for UnitTestProjectWithAutofixtureAndXunit.SimpleTheoriesTests.TestNumberTwo
         Exception doesn't have a stacktrace
        */
    }
}
