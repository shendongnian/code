    public class JobType
    {
        public Guid Id { get; set; }
        // ...
    }
    public class Job 
    {
        public JobType JobType { get; set; }
        public string EmployeeNumber { get; set; }
    }
    public class Person
    {
        public EntityCollection<Job> Jobs { get; set; }
    }
