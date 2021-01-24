    public class MainWindowVM : INotifyPropertyChanged
    {
    	private ObsCollection _Data = null;
    
    	public ObsCollection Data
    	{
    		get
    		{
    			return _Data;
    		}
    		set
    		{
    			_Data = value;
    		}
    	}
    
    	public int TotalSalary
    	{
    		get
    		{
    			return _Data.Sum(d => d.Salary);
    		}
    	}
    
    	public MainWindowVM()
    	{
    		_Data = new ObsCollection(NotifyTotalSalaryChanged);
    		LoadData();
    	}
    
    	public void LoadData()
    	{
    		_Data.Add(new Data { Name = "Test1", Salary = 1000 });
    		_Data.Add(new Data { Name = "Test2", Salary = 2000 });
    		_Data.Add(new Data { Name = "Test3", Salary = 3000 });
    		Notify("Data");
    	}
    
    	private void NotifyTotalSalaryChanged()
    	{
    		Notify("TotalSalary");
    	}
    
    	#region Property Changed Stuff
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public void Notify(string propertyName)
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    	#endregion
    }
