     public interface IRepository
     {
         List<Student> GetAllStudents();
         void AddStudent(Student student);
         Teacher GetStudentTeacher(int studentId);
     }
     public class MockRepository : IRepository
     {
         public static List<Student> Students { get; set; }
         public static List<Teachers> Teachers { get; set; }
         static MockRepository()
         {
             Students = new List<Student>();
         }
         public List<Student> GetAllStudents()
         {
             return Students.ToList();
         }
         public void AddStudent(Student student)
         {
             Students.Add(student);
         }
         public Teacher GetStudentTeacher(int studentId)
         {
             var student = Students.FirstOrDefault(s => s.Id == studentId);
             if (student != null)
             {
                 return Teachers.FirstOrDefault(t => t.Id == student.TeacherId);
             }
             return null;
         }
     }
