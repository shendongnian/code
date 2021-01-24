    private string _selectedObject;
    public string SelectedObject
    {
        get { return _selectedObject; }
        set
        {
            _selectedObject = value;
            //OnPropertyChanged(); -- INotifyPropertyChanged no need if Fody
            ReloadTasks();
        }
    }
    private void ReloadTasks()
    {
        GetTasks(SelectedProject);
    }
