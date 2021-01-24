    public TEntity RemoveNavigationProperties(TEntity input)
    		{
    
    			foreach (var item in input.GetType().GetProperties().Where(x => x.PropertyType.Namespace == input.GetType().Namespace))
    			{
    				item.SetValue(input, null);
    			}
    
    			return input;
    		}
    
