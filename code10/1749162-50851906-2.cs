    public class StudentController
    {
        private readonly IEnumerable<IStudent> _students;
        public StudentController(IEnumerable<IStudent> students)
        {
            _students = students;
        }
    }
