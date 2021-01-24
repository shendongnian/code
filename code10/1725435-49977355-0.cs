    public static TreeViewItem SearchNodeInTreeView(ItemsControl ic, XElement NodeDescription, string indent = "")
    {
    	TreeViewItem ret = null;
    	foreach (object o in ic.Items)
    	{
    		if (o is XElement)
    		{
    			var x = ic.ItemContainerGenerator.ContainerFromItem(o);
    			if (XNode.DeepEquals((o as XElement), NodeDescription))
    			{
    				ret = x as TreeViewItem;
    			}
    			else if ((o as XElement).HasElements){
    				if (x != null)
    				{
    					bool expanded = (x as TreeViewItem).IsExpanded;
    					(x as TreeViewItem).IsExpanded = true;
    					(x as TreeViewItem).UpdateLayout();
    					ret = SearchNodeInTreeView (x as TreeViewItem, NodeDescription, indent + "  ");
    					if (ret == null)
    					{
    						(x as TreeViewItem).IsExpanded = expanded;
    						(x as TreeViewItem).UpdateLayout();
    					}
    				}
    			}
    		}
    		if (ret != null)
    		{
    			break;
    		}
    	}
    	return ret;
    }
