    TreeNode lastDragDestination = null;
    DateTime lastDragDestinationTime;
    
    private void tvManager_DragOver(object sender, DragEventArgs e)
    {
    	IconObject dragDropObject = null;
    	TreeNode dragDropNode = null;
    
    	//always disallow by default
    	e.Effect = DragDropEffects.None;
    			
    	//make sure we have data to transfer
    	if (e.Data.GetDataPresent(typeof(TreeNode)))
    	{
    		dragDropNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
    		dragDropObject = (IconObject)dragDropNode.Tag;
    	}
    	else if (e.Data.GetDataPresent(typeof(ListViewItem)))
	{
		ListViewItem temp = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
		dragDropObject = (IconObject)temp.Tag;
	}
    	
    	if (dragDropObject != null)
    	{
    		TreeNode destinationNode = null;
    		//get current location
    		Point pt = new Point(e.X, e.Y);
    		pt = tvManager.PointToClient(pt);
    		destinationNode = tvManager.GetNodeAt(pt);
    		if (destinationNode == null)
    		{
    			return;
    		}
    		
    		//if we are on a new object, reset our timer
    		//otherwise check to see if enough time has passed and expand the destination node
    		if (destinationNode != lastDragDestination)
    		{
    			lastDragDestination = destinationNode;
    			lastDragDestinationTime = DateTime.Now;
    		}
    		else
    		{
    			TimeSpan hoverTime = DateTime.Now.Subtract(lastDragDestinationTime);
    			if (hoverTime.TotalSeconds > 2)
    			{
    				destinationNode.Expand();
    			}
    		}
    	}
    }
