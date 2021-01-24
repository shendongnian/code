    private readonly ApiServices _apiServices = new ApiServices();
    
    private ObservableCollection<Item>  _users;
    public ObservableCollection<Item>  Users
    {
        get { return _users; }
        set
        {
            _users = value;
            OnPropertyChanged();
        }
    }
    public ICommand GetUsersCommand
    {
        get
        {
            return new Command(async () =>
            {
                var accessToken = Settings.AccessToken;
                var user_result = await _apiServices.GetUserAsync(accessToken);
                if(user_result!=null)
                {
                     Users =new ObservableCollection<Item>(user_result.result.items);
                }
            });
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
