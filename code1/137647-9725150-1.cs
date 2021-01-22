    class Person
    {
        int Age { get; set; }
    
        [ScriptIgnore]
        Gender Gender { get; set; }
    
        string GenderString { get { return Gender.ToString(); } }
    }
