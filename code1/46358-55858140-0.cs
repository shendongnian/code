`
public class Student {
   public int StudentID { get; set; }
   public string StudentName { get; set; }
 }   
`
You can make a list like this:
`
IList<Student> studentList = new List<Student>() { 
                new Student(){ StudentID=1, StudentName="Bill"},
                new Student(){ StudentID=2, StudentName="Steve"},
                new Student(){ StudentID=3, StudentName="Ram"},
                new Student(){ StudentID=1, StudentName="Moin"}
            };
`
