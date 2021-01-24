    static class Extensions
    {
    	private static readonly FieldInfo _ownerField = typeof(InputBindingCollection).GetField("_owner", BindingFlags.Instance | BindingFlags.NonPublic);
	
    	public static void Add(this InputBindingCollection list, String eventName, Delegate handler)
    	{
    		Object ownerValue = _ownerField.GetValue( list );
		
    		DependencyObject owner = (DependencyObject)ownerValue;
    		// We assume it's a XAML Control instance:
    		Control ownerControl = (Control)owner;
		
    		switch( eventName )
    		{
    			case "click":
    				ownerControl.MouseDown += (MouseButtonEventHandler)handler;
    				break;
    			case "keydown":
    				ownerControl.KeyDown += (KeyEventHandler)handler;
				break;
			// etc...
    		}
    	}
    }
