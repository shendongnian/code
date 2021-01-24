    public class TileItem : INotifyPropertyChanged
    {
    	private string _hour;
    	private string _title;
    	private string _where;
    	private string _category;
    
    	public string Category
    	{
    		get => _category;
    		set
    		{
    			if (value == _category) return;
    			_category = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public string Hour
    	{
    		get => _hour;
    		set
    		{
    			if (value == _hour) return;
    			_hour = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public string Title
    	{
    		get => _title;
    		set
    		{
    			if (value == _title) return;
    			_title = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public string Where
    	{
    		get => _where;
    		set
    		{
    			if (value == _where) return;
    			_where = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	[NotifyPropertyChangedInvocator]
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    }
