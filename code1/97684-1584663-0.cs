    class Teacher
    {
        private List<Course> items = new List<Course>();
        public int ID { get; set; }
        public List<Course> Items { get { return items; } }
    }
    class Course
    {
        public int ID { get; set; }
        
        public override int GetHashCode()       { return base.GetHashCode(); }
        public override bool Equals(object obj) { return Equals(obj as Course); }
        public bool Equals(Course another)
        {
            return another != null && this.ID.Equals(another.ID);
        }
    } 
    static void Main(string[] args)
    {
        Teacher teacher = new Teacher { ID = 2 };
        teacher.Items.AddRange(
            new Course[] { 
                new Course{ ID = 2 },       // java
                new Course{ ID = 3 } });    // cpp
        Course cpp = new Course { ID = 3 }; // previous problem: another instance
        teacher.Items.Contains(cpp);        // now returns true
        teacher.Items.Remove(cpp);          // now returns true
    }
