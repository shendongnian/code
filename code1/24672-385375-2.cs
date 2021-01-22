    public class Teacher : Person
    {
        public Teacher(string _name) : base(_name)
        {
        }
        public int CourseAverage;
        public IList<Student> Students = new List<Student>();
        public void ComputeAverageGrade()
        {
            int sum = 0;
            foreach(Student s in Students)
            {
                sum += s.Grade;
            }
            CourseAverage = sum / Students.Count;
        }
    }
