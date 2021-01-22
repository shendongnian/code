    enum Gender { Male, Female }
    
    class Person
    {
        int Age { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        Gender Gender { get; set; }
    }
