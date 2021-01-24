    [TestFixture]
    public class JsonTests
    {
        [Test]
        public void JsonString_ShouldBeEqualAsExpected()
        {
            string jsonExpected = @"{ ""Name"": ""20181004164456"", ""objectId"": ""4ea9b00b-d601-44af-a990-3034af18fdb1%>"" }";
            string jsonActual = @"{ ""Name"": ""AAAAAAAAAAAA"", ""objectId"": ""4ea9b00b-d601-44af-a990-3034af18fdb1%>"" }";
            Entity expectedObject = JsonConvert.DeserializeObject<Entity>(jsonExpected);
            Entity actualObject = JsonConvert.DeserializeObject<Entity>(jsonActual);
            actualObject.Should().BeEquivalentTo(expectedObject);
        }
    }
