    public class OptionalNotification : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	void OnPropertyChanged(string name) ...
    
    	bool _shouldNotify;
    
    	public void EnableNotifications()
    	{
    		_shouldNotify = true;
    	}
    
    	string _someProperty;
    	public string SomeProperty
    	{
    		get { return _someProperty; }
    		set 
    		{
    			if(_someProperty == value) return
    
    			_someProperty = value;
    
    			if(_shouldNotify) OnPropertyChanged("SomeProperty");
    		}
    	}
    }
