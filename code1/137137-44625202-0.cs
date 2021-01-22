    public class Person
    {
        // Before C# 6.0
        [Display(Name = "Age", ResourceType = typeof(Testi18n.Resource))]
        public string Age { get; set; }
    
        // After C# 6.0
        // [Display(Name = nameof(Resource.Age), ResourceType = typeof(Resource))]
    }
