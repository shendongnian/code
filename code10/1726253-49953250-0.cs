    public class StudentEntity : INotifyPropertyChanged
    {
        private string studentId;
        public string StudentId
        {
            get { return studentId; }
            set
            {
                studentId = value;
                OnPropertyChanged("StudentId");
            }
        }
        private string studentStatus;
        public string StudentStatus
        {
            get { return studentStatus; }
            set
            {
                studentStatus = value;
                OnPropertyChanged("StudentStatus");
            }
        }
        public string getStatusChangeDate { get; set; }
        public StudentEntity(string studentId, string studentStatus)
        {
            StudentId = studentId;
            StudentStatus = studentStatus;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var person = new StudentEntity("101", "Accept");
            person.PropertyChanged += Person_PropertyChanged;
            person.StudentStatus = "Reject";
            Console.ReadLine();
        }
        private static void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StudentEntity studentEntity = sender as StudentEntity;
            if (e.PropertyName == "StudentStatus")
            {
                studentEntity.getStatusChangeDate = DateTime.Now.ToString();
            }
        }
    }
