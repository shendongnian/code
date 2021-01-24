    private void PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
    	ListViewItem lvi = null;
    	var visParent = VisualTreeHelper.GetParent(sender as FrameworkElement);
    	while (lvi == null && visParent != null)
    	{
    		lvi = visParent as ListViewItem;
    		visParent = VisualTreeHelper.GetParent(visParent);
    	}
    	if (lvi == null) { return; }
    	lvi.IsSelected = true;
    }
