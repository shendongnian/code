    public class Student
    {
        private string Name;
        public Guid ID { get; private set; }
        public Student(string name)
        {
            this.Name = name;
            this.ID = new Guid();
        }
    }
    public class StudentDirectory
    {
        public Dictionary<Guid, Student> Directory { get; private set; }
        public StudentDirectory() : this(new Dictionary<Guid, Student>())
        { }
        public StudentDirectory(Dictionary<Guid, Student> directory)
        {
            this.Directory = directory;
        }
        public void AddStudent(Student entry)
        {
            bool idExists = Directory.ContainsKey(entry.ID);
            if(idExists)
            {
                Directory[entry.ID] = entry;
            }
            else
            {
                Directory.Add(entry.ID, entry);
            }
        }
        public void AddStudent()
        {
            Console.WriteLine("Enter the new stuent's name.\n");
            string name = Console.ReadLine();
            Student entry = new Student(name);
            AddStudent(entry);
        }
    }
