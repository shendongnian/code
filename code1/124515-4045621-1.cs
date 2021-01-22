    namespace MyLibraryOrApplication
    {
    	public static class FrameworkElementExtensions
    	{
    		public static void HandleWhenLoaded(this FrameworkElement el, RoutedEventHandler handler)
    		{
    			if ((bool)el.GetValue(View.IsLoadedProperty))
    			{
    				// el already loaded, call the handler now.
    				handler(el, null);
    				return;
    			}
    			// el not loaded yet. Attach a wrapper handler that can be removed upon execution.
    			RoutedEventHandler wrapperHandler = null;
    			wrapperHandler = delegate
    			{
    				el.Loaded -= wrapperHandler;
    				el.SetValue(View.IsLoadedProperty, true);
    
    				handler(el, null);
    			};
    			el.Loaded += wrapperHandler;
    		}
    	}
    }
