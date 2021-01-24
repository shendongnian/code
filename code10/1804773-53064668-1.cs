    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Student> studentsList = new ObservableCollection<Student>();
        public ObservableCollection<Student> StudentsList
        {
            get { return studentsList; }
            set
            {
                studentsList = value;
                NotifyPropertyChanged();
            }
        }
        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            StudentsList.Add(new Student("Paul", "LName1", "FName1"));
            StudentsList.Add(new Student("Alex", "LName2", "FName2"));
            StudentsList.Add(new Student("Steve", "LName3", "FName3"));
        }
        #region Notify Property
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            if (!string.IsNullOrWhiteSpace(propName))
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
                }));
            }
        }
        #endregion
    }
