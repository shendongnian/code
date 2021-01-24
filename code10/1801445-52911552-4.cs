    public struct Student
    {
       public Student(string name, int studentId, string major)
       {
          Name = name;
          StudentId = studentId;
          Major = major;
       }
    
       public string Name { get; set; }
       public int StudentId { get; set; }
       public string Major { get; set; }
    
       public override string ToString() => Name + ", " + StudentId + ", " + Major;
    }
