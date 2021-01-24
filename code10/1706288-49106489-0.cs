    public class Student
    {
        public int Id { get; set; }
        public List<Agent> Agents { get; set; }
    
        public Student()
        {
            Agents = new List<Agent>();
        }
    }
