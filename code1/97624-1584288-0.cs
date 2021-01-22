    class Professor
    {
      string profid;
      public string ProfessorID
      {
         get { return profid;}
         set { profid=value;}
      }
    
      public Student {
         get { return st;}
         set { st=value;}
      }
    
      student st;
    
    }
    
    
    public void GetDetails()
    {
      Student s = new Student();
      s.StudentId = someId;
      s.name = someName;
      Professor prf = new Professor { ProfessorID=1, Student = s;};
    }
