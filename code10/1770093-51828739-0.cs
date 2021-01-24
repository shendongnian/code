    public class EditGolfRoundViewModel : INotifyPropertyChanged
    {
    ApiServices _apiServices = new ApiServices();
    private string _message;
    private ObservableCollection<GolfCourse> _courses;
    private ObservableCollection<GolfRoundCategory> _roundCategories;
    private GolfCourse _selectedGolfCourse;
    private GolfRoundCategory _selectedGolfRoundCategory;
    private GolfRound _golfRound;
    public EditGolfRoundViewModel()
    {
        LoadCourses();
        LoadRoundCategories();
    }
    public GolfRound GolfRound
    {
        get { return _golfRound; }
        set
        {
            _golfRound = value;
            OnPropertyChanged();
        }
    }
    public string Message
    {
        get { return _message; }
        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<GolfCourse> GolfCourses
    {
        get { return _courses; }
        set
        {
            if (_courses != value)
            {
                _courses = value;
                OnPropertyChanged();
            }
        }
    }
    public ObservableCollection<GolfRoundCategory> GolfRoundCategories
    {
        get { return _roundCategories; }
        set
        {
            _roundCategories = value;
            OnPropertyChanged();
        }
    }
    public GolfCourse SelectedGolfCourse
    {
        get { return _selectedGolfCourse; }
        set
        {
            _selectedGolfCourse = value;
            OnPropertyChanged("SelectedGolfCourse");
        }
    }
    public GolfRoundCategory SelectedGolfRoundCategory
    {
        get { return _selectedGolfRoundCategory; }
        set
        {
            _selectedGolfRoundCategory = value;
            OnPropertyChanged();
        }
    }
    public ICommand EditCommand
    {
        get
        {
            return new Command(async () =>
            {
                GolfRound.GolfCourseID = SelectedGolfCourse.GolfCourseID;
                GolfRound.GolfCourse = SelectedGolfCourse;
                GolfRound.GolfRoundCategoryID = SelectedGolfRoundCategory.GolfRoundCategoryID;
                GolfRound.GolfRoundCategory = SelectedGolfRoundCategory;
                GolfRound.LastModifiedUTC = System.DateTime.Now;
                await _apiServices.PutGolfRoundAsync(GolfRound, Settings.AccessToken);
            });
        }
    }
    public ICommand DeleteCommand
    {
        get
        {
            return new Command(async () =>
            {
                await _apiServices.DeleteGolfRoundAsync(GolfRound.GolfRoundID, Settings.AccessToken);
            });
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    private async void LoadCourses()
    {
        GolfCourses = new ObservableCollection<GolfCourse>(await _apiServices.GetGolfCoursesAsync(Settings.AccessToken));
        if (GolfCourses != null && GolfCourses.Count() > 0)
            SelectedGolfCourse = GolfCourses[0];
    }
    private async void LoadRoundCategories()
    {
        GolfRoundCategories = new ObservableCollection<GolfRoundCategory>(await _apiServices.GetGolfRoundCategoriesAsync(Settings.AccessToken));
        if (GolfRoundCategories != null && GolfRoundCategories.Count() > 0)
            SelectedGolfRoundCategory = GolfRoundCategories[0];
        
    }
    }
