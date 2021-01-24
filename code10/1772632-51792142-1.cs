    public class Person
    {
        [Required]
        [MustBeBillOrBob]
        public string FirstName { get; set; }
    
        ...
    }
