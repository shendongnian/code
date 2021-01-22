    public class Student
    {
      public Student(Student student)
      {
        FirstName = student.FirstName;
        LastName = student.LastName;
      }
    
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }
    // wherever you have the list
    List<Student> students;
    // and then where you want to make a copy
    List<Student> copy = students.Select(s => new Student(s)).ToList();
