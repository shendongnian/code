    public class Student
    {
       public int Number { get; set; }
       public string Name { get; set; }
       public int YearLevel { get; set; }
    }
    public class School
    {
       public string Name { get; set; }
       public string Type { get; set; }
       public List<Student> Students { get; set; }
    }
