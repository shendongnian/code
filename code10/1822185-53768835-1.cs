    public class PersonSerializationTest
    {
        [Fact]
        public void SerializePerson_LastNameCaps()
        {
            var person = new Person
            {
                FirstName = "George",
                LastName = "Washington"
            };
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CustomResolver()
            };
            var serialized = JsonConvert.SerializeObject(person, settings);
            var expected = @"{""FirstName"":""George"",""LastName"":""WASHINGTON""}";
            Assert.Equal(expected, serialized);
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
