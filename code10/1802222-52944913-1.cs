    public class PersonParser
    {
        public IEnumerable<Person> Parse(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }
            if (string.IsNullOrWhiteSpace(content))
            {
                yield break;
            }
            // skip 1st array, which contains the property names
            var values = JsonConvert.DeserializeObject<string[][]>(content).Skip(1);
            foreach (string[] properties in values)
            {
                if (properties.Length != 4)
                {
                    // ignore line? thrown exception?
                    // ...
                    continue;
                }
                var person = new Person
                {
                    Name = properties[0],
                    Surname = properties[1],
                    Street = properties[2],
                    Phone = properties[3]
                };
                yield return person;
            }
        }
    }
