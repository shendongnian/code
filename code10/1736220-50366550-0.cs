    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            XDocument xDocument = XDocument.Load("icsemmelle.xml");
            List<XElement> xStudents = xDocument.Descendants("student").ToList();
            foreach(XElement xStudent in xStudents)
            {
                students.Add(new Student { Name = xStudent.Attribute("name").Value });
            }
        }
    }
    class Student
    {
        public string Name { get; set; }
    }
