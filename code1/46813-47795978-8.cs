    public class ProjectViewModel
    {
        public ObservableCollection<Project> Projects { get; set; } = 
                   new ObservableCollection<Project>();
        public ProjectViewModel()
        {
            //Add items to Projects
        }
    
        public ICommand ProjectClick
        {
            get { return new DelegateCommand(new Action<object>(OpenProjectInfo)); }
        }
    
        private void OpenProjectInfo(object _project)
        {
            ProjectDetailView project = new ProjectDetailView((Project)_project);
            project.ShowDialog();
        }
    }
