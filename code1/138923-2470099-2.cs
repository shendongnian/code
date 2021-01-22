    public static class PropertyNotificationRegistry
    {
    	static IDictionary<INotifyPropertyChanged, bool> _registeredClasses
    		= new Dictionary<INotifyPropertyChanged, bool>;
    
    	static void Register(INotifyPropertyChanged o, bool shouldNotify)
    	{
    		if(!(_registeredClasses.ContainsKey(o)) _registeredClasses.Add(o, shouldNotify);
    		// could also implement logic to update an existing class in the dictionary
    	}
    
    	public static void ShouldNotifyWhenPropertiesChange(this INotifyPropertyChanged o)
    	{
    		Register(o, true);
    	}
    
    	public static void ShouldNotNotifyWhenPropertiesChange(this INotifyPropertyChanged o)
    	{
    		Register(o, false);
    	}
    
    	public static void NotifyPropertyChanged(this INotifyPropertyChanged o, Action notificationAction)
    	{
    		if(_registeredClasses.ContainsKey(o))
    		{
    			bool shouldNotify = _registeredClasses.Where(x => x.Key == o).Single().Value;
    
    			if(shouldNotify) notificationAction();
    		}
    	}
    }
    
    public class EntityUsingNotificationRegistry : INotifyPropertyChanged
    {
    	... // all the standard INotifyPropertyChanged stuff
    
    	string _someProperty;
    	public string SomeProperty
    	{
    		get { return _someProperty; }
    		set 
    		{
    			if(_someProperty == value) return;
    
    			_someProperty = value;
    			this.NotifyPropertyChanged(() => OnPropertyChanged("SomeProperty"));
    		}
    	}
    }
    
    public class SomethingInstantiatingOurEntity
    {
    	public void DoSomething()
    	{
    		var entity1 = new EntityUsingNotificationRegistry();
    		entity1.ShouldNotifyWhenPropertiesChange();
    
    		var entity2 = new EntityUsingNotificationRegistry();
    		entity2.ShouldNotNotifyWhenPropertiesChange();
    
    		entity1.SomeProperty = "arbitrary string"; // raises event
    		entity2.SomeProperty = "arbitrary string"; // does not raise event
    
    		var entity3 = new EntityUsingNotificationRegistry();
    		entity3.SomeProperty = "arbitrary string"; // does not raise event
    		entity3.ShouldNotifyWhenPropertiesChange();
    		entity3.SomeProperty = "another arbitrary string"; // now raises event
    	}
    }
