    private ObservableCollection<StudentEnrollmentViewModel> _FilteredStudentEnrollments;
    public ObservableCollection<StudentEnrollmentViewModel> FilteredStudentEnrollments
    {
        get { return _FilteredStudentEnrollments; }
        set
        {
            SetProperty(ref _FilteredStudentEnrollments, value);
            RaisePropertyChanged("Score01");
        }
    }
    private string _selectedYear;
    public string SelectedYear
    {
        get
        {
            return _selectedYear;
        }
        set 
        { 
           SetProperty(ref _selectedYear, value);
           RaisePropertyChanged("Score01");
           RefreshFilteredStudentEnrollmentData();
        }
    }
    public double Score01
    {
        get
        {
            return FilteredStudentEnrollments.
                Where(y => y.Year == SelectedYear).Select(s => s.Score01).Sum();            
        }
    }
