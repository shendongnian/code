    public class MyViewModel : INotifyPropertyChanged
    {
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private ObservableCollection<Issue> issues = new ObservableCollection<Issue>();
    	public ObservableCollection<Issue> Issues { get {return issues;} }
        private ObservableCollection<string> users = new ObservableCollection<string>();
    	public ObservableCollection<string> Users { get {return users;} }
    	
    	private string user;
    	public string User 
    	{
    		get 
    		{
    			return user;
    		}
    		set
    		{
    			user = value;
    			NotifyPropertyChanged();
    		}
    	}
    	
    	private ICommand userChangedCommand;
    	
    	public ICommand UserChangedCommand
    	{
    		get
    		{
    			return userChangedCommand ?? (userChangedCommand = new RelayCommand(
    				x =>
    				{
    					OnUserChanged();
    				}));
    		}
    	}
    	private ICommand loadedCommand;
    	
    	public ICommand LoadedCommand
    	{
    		get
    		{
    			return loadedCommand?? (loadedCommand= new RelayCommand(
    				x =>
    				{
    					// Write Code here to populate Users collection.
    				}));
    		}
    	}
    
    	private void OnUserChanged()
    	{
    		Issues.Clear();
    	
    		string name = this.User;
    		Issues fetchedIssues = new Issues();
    	
    		var issuesList = fetchedIssues.FetchIssues(name); // returns the list of Issues in a type of --> IQueryable<Issue>
    		foreach (var issue in issuesList)
    		{
    			Issues.Add(issue);
    		}    
    	}
    	
    	private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    
    }
