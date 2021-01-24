    static class Extensions
    {
    	private static readonly FieldInfo _ownerField = typeof(InputBindingCollection).GetField("_owner", BindingFlags.Instance | BindingFlags.NonPublic);
	
	    public static void Add(this InputBindingCollection list, RoutedEvent routedEvent, RoutedEventHandler handler)
	    {
		    UIElement owner = (UIElement)_ownerField.GetValue( list );;
		    owner.AddHandler( routedEvent, handler );
	    }
    }
