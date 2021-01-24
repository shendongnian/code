    namespace student
    {
       class Student
       {
          public string Name;
          public string Subject;
          public double Grade;
    
          public Student(string aName, string aSubject, double Grade)
          {
             Name = aName;
             Subject = aSubject;
             grade=Grade;
          }
    
          private double grade
          {
             get { return Grade; }
             set
             {
                if (value > 5.3 || value <= 0)
                {
                   Grade = Double.NaN;
                }
                else
                {
                   Grade = value;
                }
    
             }
          }
                    
          public bool HasHonours()
          { 
             if (grade >= 3.5)
             {
                return true;
             }
             else
             {
                 return false;
             } 
          }
       }
    } 
