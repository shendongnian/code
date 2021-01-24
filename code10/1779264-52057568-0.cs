    // Use for database
    [Table("Person")]
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    // Use in business logic 
    public partial class Person : Subject
    {
        public override string FullName => FirstName + " " + LastName;
        public override SubjectType SubjectType => SubjectType.Person;
        public string FirstName { get; set; }
        public string LastName { get; set; }
     }
