    using FluentAssertions;
    using FluentAssertions.Json;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    [TestFixture]
    public class JsonTests
    {
        [Test]
        public void JsonObject_ShouldBeEqualAsExpected()
        {
            JToken expected = JToken.Parse(@"{ ""Name"": ""20181004164456"", ""objectId"": ""4ea9b00b-d601-44af-a990-3034af18fdb1%>"" }");
            JToken actual = JToken.Parse(@"{ ""Name"": ""AAAAAAAAAAAA"", ""objectId"": ""4ea9b00b-d601-44af-a990-3034af18fdb1%>"" }");
            actual.Should().BeEquivalentTo(expected);
        }
    }
