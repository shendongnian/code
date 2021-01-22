    public class Person
    {
        public virtual int PersonId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Surname { get; set; }
    }
    public class Project
    {
        public virtual int ProjectId { get; set; }
        public virtual string Title { get; set; }
        public virtual Person ProjectManager { get; set; }
        public virtual Person Contact { get; set; }
    }
