    public abstract class BaseModel
    {
        public int ID { get; set; }
    }
    public abstract class BasePerson
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
    public class Student
    {
        public DateTime EnrollmentDate
    }
    public class Instructor
    {
        public DateTime HireDate
    }
