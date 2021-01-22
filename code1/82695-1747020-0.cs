     public static IObservable<Event<MouseButtonEventArgs>> 
                                          GetMouseDown (this UIElement el)
    	{                        
    		var allevents = Observable.FromEvent<MouseButtonEventHandler, MouseButtonEventArgs>
    			(   h => new MouseButtonEventHandler(h), 
    				h => el.MouseDown += h, 
    				h=> el.MouseDown -= h
    			 );
    
    		return allevents;            
    	}	
