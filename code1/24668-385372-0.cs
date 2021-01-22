    class Student {
       public string Name { get; private set; }
 
       public Student(string name) {
          if (string.IsNullOrEmpty(name)) throw new ArgumentException();
          this.Name = name;
       }
    }
    class Teacher {
       public string Name { get; private set; }
       public List<Course> Courses { get; private set; }
  
       public Grade GetAverageCourseGrade() {
           int totalCourseGrade;
           foreach (Course course in this.Courses) {
              totalCourseGrade += course.GetAverageGrade().Value;
           }
           return new Grade(totalCourseGrade / this.Courses.Count);
       }
      
       public Teacher(string name) {
           if (string.IsNullOrEmpty(name)) throw new ArgumentException();
           this.Name = name;
           this.Courses = new List<Course>();
       }
    }
    class Course {
       public string Name { get; private set; }
       public IEnumerable<Student, Grade> StudentGrades { get; private set; }
       public Grade GetAverageGrade() {
          int totalGrade;
          // could use LINQ, but I'll make it slightly more explicit
          foreach (KeyValuePair<Student, Grade> studentGrade in this.StudentGrades) {
             Grade grade = kvp.Value;
             totalGrade += grade.Value;
          }
          return new Grade(totalGrade / this.StudentGrades.Count());
       }
       public Course(string name) {
           if (string.IsNullOrEmpty(name)) throw new ArgumentException();
           this.Name = name;
           this.StudentGrades = new Dictionary<Student, Grade>();
       }
    }
    class Grade {
       public int Value { get; private set; }
       public char Letter { 
           get {
              switch (this.Value / 10) {
                 case 10: case 9:
                   return 'A';
                 case 8:
                   return 'B';
                 case 7:
                   return 'C';
                 case 6:
                   return 'D';
                 default:
                   return 'F';
              }
           }
       }
       public Grade(int value) {
          if (value < 0 || value > 100) throw new ArgumentOutOfRangeException();
          this.Value = value;
       }
    }
 
    class Program {
       static int Main(string[] args) {
          Teacher john = new Teacher("John Smith");
          Course cs101 = new Course("Computer Science 101");
          john.Courses.Add(cs101);
          Student mark = new Student("Mark Brackett");
          Student xesaniel = new Student("Xesaniel");
          cs101.Students.Add(mark, new Grade(90));
          cs101.Students.Add(xesaniel, new Grade(95));
          Console.WriteLine(john.GetAverageCourseGrade());
       }
    }
