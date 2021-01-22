    public enum Gender
    {
       [EnumMember(Value = "male")] 
       Male,
       [EnumMember(Value = "female")] 
       Female
    }
    
    class Person
    {
        int Age { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        Gender Gender { get; set; }
    }
