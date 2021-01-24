    public class StudentViewModel
    {
        private Student _student;
        public StudentViewModel(Student student, int id)
        {
            _student = student;
            ID = id;
        }
        public int ID { get; set; }
        public string Name
        {
            get { return _student.Name; }
            set { _student.Name = value; }
        }
        public string FavoriteSubject
        {
            get { return _student.FavoriteSubject; }
            set { _student.FavoriteSubject = value; }
        }
        public string GPA
        {
            get { return _student.GPA; }
            set { _student.GPA = value; }
        }
    }
