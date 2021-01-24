    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<Student> students;
        public List<Student> Students
        {
            get { return students; }
            set { students = value; OnPropertyChanged(); }
        }
        private bool? isAllSelected;
        public bool? IsAllSelected
        {
            get { return isAllSelected; }
            set
            {
                isAllSelected = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand CheckStudentCommand { get; private set; }
        public RelayCommand CheckAllStudentsCommand { get; private set; }
        public MainWindowViewModel()
        {
            Students = new List<Student>()
            {
                new Student { Name = "Walter" },
                new Student { Name = "Jenny" },
                new Student { Name = "Joe" }
            };
            CheckStudentCommand = new RelayCommand(OnCheckStudent);
            CheckAllStudentsCommand = new RelayCommand(OnCheckAllStudents);
            IsAllSelected = false;
        }
        private void OnCheckAllStudents()
        {
            if (IsAllSelected == true)
                Students.ForEach(x => x.IsChecked = true);
            else
                Students.ForEach(x => x.IsChecked = false);
        }
        private void OnCheckStudent()
        {
            if (Students.All(x => x.IsChecked))
                IsAllSelected = true;
            else if (Students.All(x => !x.IsChecked))
                IsAllSelected = false;
            else
                IsAllSelected = null;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
