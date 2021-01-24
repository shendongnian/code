    public class Task : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SuspenseDatetime { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public int CreatedById { get; set; }
        public bool Completed { get; set; }
        public bool Archived { get; set; }
        public Person CreatedBy { get; set; }
        public virtual ICollection<Person> PeopleAssigned { get; set; }
    }
    public class Person : BaseModel
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Title { get; set; }
        public ICollection<TestEvent> TestEventsLed { get; set; }
        public ICollection<TestEvent> TestEventsCreated { get; set; }
        public ICollection<Program> ProgramsLed { get; set; }
        public ICollection<Task> TasksCreated { get; set; }
        public ICollection<PersonalEvent> PersonalEventsCreated { get; set; }
        public virtual ICollection<Role> RolesHeld { get; set; }
        public virtual ICollection<Task> TasksAssigned { get; set; }
    }
