    class Program
    {
        static void Main(string[] args)
        {
            IStudent s1 = new Student();
            IStudent s2 = new Student();
            s1.ExamineStudentsMembers(s1);
        }
    }
    public interface IStudent
    {
        void ExamineStudentsMembers(IStudent anotherStudent);
    }
    public class Student : IStudent
    {
        private string _studentsPrivateMember;
        public Student()
        {
            _studentsPrivateMember = DateTime.Now.Ticks.ToString();
        }
        public void ExamineStudentsMembers(IStudent anotherStudent)
        {
            Console.WriteLine(anotherStudent._studentsPrivateMember);
        }
    }
