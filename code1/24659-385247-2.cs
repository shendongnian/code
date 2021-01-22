    public class Student
    {
        int grade; //0 - 100 as opposed to the characters A, B, C, etc.
        string teacher; //For the teacher of the class the student is in.
        public void SetGrades()
        {
            grade = 100;
        }
        public void SetTeacher()
        {
            teacher = "John Smith";
        }
    }
    class Program
    {
        public static void Main()
        {
            Student Jim;
            Jim = new Student();
            Jim.SetTeacher();
            Jim.SetGrades();
        }
    }
