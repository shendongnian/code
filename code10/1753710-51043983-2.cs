    public class Device : INotifyPropertyChanged
    {
    	public string Name
    	{
    		get
    		{
    			return _name;
    		}
    		set
    		{
    			if (value != _name)
    			{
    				_name = value;
    				Saved = false;
    				NotifyPropertyChanged(nameof(Name));
    			}
    		}
    	}
    	private string _name;
    
    
    	public bool Saved
    	{
    		get
    		{
    			return _saved;
    		}
    		set
    		{
    			if (value != _saved)
    			{
    				_saved = value;
    				NotifyPropertyChanged(nameof(Saved));
    			}
    		}
    	}
    	private bool _saved = true;
    
    	public void Save()
    	{
    		//Saving..
    		Saved = true;
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	public void NotifyPropertyChanged(string info)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    	}
    }
