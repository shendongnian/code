    ...
    this.ToolboxItems = new ToolboxItem[] 
    	{
    		GetToolboxItem(typeof(IfElseActivity))
    	};
    ...
    internal static ToolboxItem GetToolboxItem(Type toolType)
    {
    	if (toolType == null)
    		throw new ArgumentNullException("toolType");
    
    	ToolboxItem item = null;
    	if ((toolType.IsPublic || toolType.IsNestedPublic) && typeof(IComponent).IsAssignableFrom(toolType) && !toolType.IsAbstract)
    	{
    		ToolboxItemAttribute toolboxItemAttribute = (ToolboxItemAttribute)TypeDescriptor.GetAttributes(toolType)[typeof(ToolboxItemAttribute)];
    		if (toolboxItemAttribute != null && !toolboxItemAttribute.IsDefaultAttribute())
    		{
    			Type itemType = toolboxItemAttribute.ToolboxItemType;
    			if (itemType != null)
    			{
    				// First, try to find a constructor with Type as a parameter.  If that
    				// fails, try the default constructor.
    				ConstructorInfo ctor = itemType.GetConstructor(new Type[] { typeof(Type) });
    				if (ctor != null)
    				{
    					item = (ToolboxItem)ctor.Invoke(new object[] { toolType });
    				}
    				else
    				{
    					ctor = itemType.GetConstructor(new Type[0]);
    					if (ctor != null)
    					{
    						item = (ToolboxItem)ctor.Invoke(new object[0]);
    						item.Initialize(toolType);
    					}
    				}
    			}
    		}
    		else if (!toolboxItemAttribute.Equals(ToolboxItemAttribute.None))
    		{
    			item = new ToolboxItem(toolType);
    		}
    	}
    	else if (typeof(ToolboxItem).IsAssignableFrom(toolType))
    	{
    		// if the type *is* a toolboxitem, just create it..
    		//
    		try
    		{
    			item = (ToolboxItem)Activator.CreateInstance(toolType, true);
    		}
    		catch
    		{
    		}
    	}
    
    	return item;
    }
