    public class UnitsNetJsonConverterTests
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        protected UnitsNetJsonConverterTests()
        {
            _jsonSerializerSettings = new JsonSerializerSettings {Formatting = Formatting.Indented};
            _jsonSerializerSettings.Converters.Add(new UnitsNetJsonConverter());
        }
        private string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings).Replace("\r\n", "\n");
        }
        private T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }
        public class Serialize : UnitsNetJsonConverterTests
        {
    // Snip 
            [Fact]
            public void Mass_ExpectConstructedValueAndUnit()
            {
                Mass mass = Mass.FromPounds(200);
                var expectedJson = "{\n  \"Unit\": \"MassUnit.Pound\",\n  \"Value\": 200.0\n}";
                string json = SerializeObject(mass);
                Assert.Equal(expectedJson, json);
            }
    // Snip 
