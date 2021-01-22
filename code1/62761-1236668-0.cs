    private void ChangeTimeout(Component component, int timeout)
    		{
    			if (!component.GetType().Name.Contains("TableAdapter"))
    			{
    				return;
    			}
    
    			PropertyInfo adapterProp = component.GetType().GetProperty("CommandCollection", BindingFlags.NonPublic | BindingFlags.GetProperty | BindingFlags.Instance);
    			if (adapterProp == null)
    			{
    				return;
    			}			
    
    			SqlCommand[] command = adapterProp.GetValue(component, null) as SqlCommand[];
    
    			if (command == null)
    			{
    				return;
    			}
    
    			command[0].CommandTimeout = timeout;			
    		}
