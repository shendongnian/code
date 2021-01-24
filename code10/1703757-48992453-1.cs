    private void Mouse_Down(object sender, MouseButtonEventArgs e)
    {
    	var cm = ContextMenuService.GetContextMenu(sender as DependencyObject);
    	if (cm==null)
    	{
    		return;
    	}
    	cm.Placement = PlacementMode.Top;
    	cm.PlacementTarget = sender as UIElement;
    	cm.IsOpen = true;
    }
