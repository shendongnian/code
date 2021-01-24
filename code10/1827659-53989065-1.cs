    class Student
    {
       public string Name { get; set; };
       public string Subject { get; set; };
    
       public double Grade 
       {
          get
          {
             return Grade;
          }
    
         set
         {
            // value is less than or equal to '0' or greater than '5.3' so return 'N/A'
            if(!(value <= 0 || value > 5.3))
               Grade = value;
         }
       };
    
       public Student(string name, string subject, double grade)
       {
          this.Name = name;
          this.Subject = subject;
          this.Grade = grade;
       }
    
       public bool HasHonours()
       { 
          if (grade > 3.5)
          {
             return true;
          }
          else
          {
             return false; // Because - Grade is Less than or equal to 3.5
          } 
       }
    }
