    public interface IEntity : INotifyPropertyChanged
    {
    	string SomeProperty { get; set; }
    }
    
    public class Entity : IEntity
    {
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public void OnPropertyChanged(string name) ...
    
    	string _someProperty;
    	public string SomeProperty
    	{
    		get { return _someProperty; }
    		set 
    		{
    			if(_someProperty == value) return
    
    			_someProperty = value;
    			OnPropertyChanged("SomeProperty");
    		}
    	}
    }
    
    public class EntityNotificationProxy : IEntity
    {
    	IEntity _inner;
    
    	public EntityNotificationProxy(IEntity entity)
    	{
    		_inner = entity;
    		_inner.PropertyChanged += (o,e) => { if(ShouldNotify) OnPropertyChanged(o,e); }
    	}
    
    	public bool ShouldNotify { get; set; }
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	void OnPropertyChanged(object sender, PropertChangedEventArgs e)
    	{
    		PropertyChangedEventHandler handler = PropertyChanged;
    		if(handler != null) handler(sender, e);
    	}
    
    	public string SomeProperty
    	{
    		get { return _inner.SomeProperty; }
    		set 
    		{
    			if(_inner.SomeProperty == value) return
    
    			_inner.SomeProperty = value;
    		}
    	}
    }
