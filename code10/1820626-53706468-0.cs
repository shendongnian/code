    private string _selectedProjectsList;
    public string SelectedProjectsList
    {
        get
        {
            return _selectedProjectsList;
        }
        set
        {
            _selectedProjectsList = value;
            // project selection has been changed, populate your task list now!
        }
    }
