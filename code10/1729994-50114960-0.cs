    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _db;
        public StudentService(IUnitOfWork uow)
        {
            _db = uow;
        }
        public IEnumerable<StudentView> GetStudentViews()
        {
            List<Student> students = _db.Students.GetAll().ToList();
            return Mapper.Map<List<Student>, List<StudentView>>(students);
        }
    }
