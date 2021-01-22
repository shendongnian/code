    public class MyDefaultModelBinder : DefaultModelBinder
    {
    	protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value)
    	{ 
    	    ModelMetadata propertyMetadata = bindingContext.PropertyMetadata[propertyDescriptor.Name]; 
    	    propertyMetadata.Model = value;
    	    string modelStateKey = CreateSubPropertyName(bindingContext.ModelName, propertyMetadata.PropertyName);
    
    	    // Try to set a value into the property unless we know it will fail (read-only 
    	    // properties and null values with non-nullable types)
    	    if (!propertyDescriptor.IsReadOnly) { 
    		try {
    		    if (value == null)
    		    {
    			propertyDescriptor.SetValue(bindingContext.Model, value);
    		    }
    		    else
    		    {
    			Type valueType = value.GetType();
    
    			if (valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof(EntityCollection<>))
    			{
    			    IListSource ls = (IListSource)propertyDescriptor.GetValue(bindingContext.Model);
    			    IList list = ls.GetList();
    
    			    foreach (var item in (IEnumerable)value)
    			    {
    				list.Add(item);
    			    }
    			}
    			else
    			{
    			    propertyDescriptor.SetValue(bindingContext.Model, value);
    			}
    		    }
    		    
    		}
    		catch (Exception ex) {
    		    // Only add if we're not already invalid
    		    if (bindingContext.ModelState.IsValidField(modelStateKey)) { 
    			bindingContext.ModelState.AddModelError(modelStateKey, ex); 
    		    }
    		} 
    	    }
    	}
    }
