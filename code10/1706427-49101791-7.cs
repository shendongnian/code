    static class Extensions
    {
    	private static readonly FieldInfo _ownerField = typeof(InputBindingCollection).GetField("_owner", BindingFlags.Instance | BindingFlags.NonPublic);
    	
    	public static void Add(this InputBindingCollection list, RoutedEvent routedEvent, RoutedEventHandler handler)
    	{
    		UIElement owner = (UIElement)_ownerField.GetValue( list );;
    		owner.AddHandler( routedEvent, handler );
    	}
    
    	public static void Add(this InputBindingCollection list, String eventName, Delegate handler)
    	{
    		UIElement owner = (UIElement)_ownerField.GetValue(list);
    		EventInfo eventInfo = owner.GetType().GetEvent( eventName, BindingFlags.Instance | BindingFlags.Public );
    		eventInfo.AddEventHandler( owner, handler );
    	}
    	
    	public static void Add<T>(this InputBindingCollection list, Action<T> callback)
    		where T : UIElement
    	{
    		T owner = (T)_ownerField.GetValue(list);
    		callback( owner );
    	}
    }
