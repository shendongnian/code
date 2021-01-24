    private ObservableCollection<Student> _students;
    
    public ObservableCollection<Student> Students
        {
            get => _students;
            set
                {
                    if (_students == value) return;
                    _students = value;
                    RaisePropertyChanged("Students");
                }
            }
