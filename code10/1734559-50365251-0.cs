    public class Faculty
    {
        private List<Student> students;
    
        static public T GetValue<T>(int id, Func<Student,T> prop)
        {
            return prop(students.Where(x => x.ID == id).FirstOrDefault());
        }
    }
