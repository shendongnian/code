    private ICommand reloadTasks;
    public ICommand ReloadTasksCommand => this.reloadTasks?? (this.reloadTasks= new RelayCommand(this.ReloadTasks));
    public string SelectedProject{ get; set; }
    private void ReloadTasks()
    {
        GetTasks(this.SelectedProject);
    }
