    public class StudentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        // ...rest of the properties here
        
        // And then add the CreateAndUpdateProperties model as a property
        public CreateAndUpdateProperties { get; set; }
    }
