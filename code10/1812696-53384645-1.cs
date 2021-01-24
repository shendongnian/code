    private T DeserialzeFrom<T>(string xml)
    {
        using (var reader = new StringReader(xml))
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
        }
    }
    [Test]
    public void ShouldDeserializeCompany()
    {
        var xml = // Build xml string;
         
        // Expected deserialized object
        var expected = new Company
        {
            Tables = new List<Tables>
            {
                new Tables { Table = new Table { Id = "3" }},
                new Tables { Table = new Table { Id = "4" }}
            }
        };
        var actual = DeserialzeFrom<Company>(xml);
        actual.ShouldBeEquivalentTo(expected); // Test passing
    }
