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
            // upd: actual code for populating the list
            tasks = context.GetProjectsTasks(SelectedProjectsList);
            TasksList = new BindableCollection<string>();
            foreach (Task task in tasks)
            {
                TasksList.Add(task.TaskName);
            }
            NotifyOfPropertyChange(() => TasksList);
        }
    }
