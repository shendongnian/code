    var container = new Container();
    container.Items = new List<ContainerItem>
    {
    	new ContainerItem
    	{
    		ChildItems = new List<ContainerItem>
    		{
    			new ContainerItem
    			{
    				Container = container // <-- do the same for all non direct items
    			}
    		}
    	}
    };
