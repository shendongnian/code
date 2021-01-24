	private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) 
	{
		TabItem ti = ((TabControl)sender).SelectedItem as TabItem;
		var content = ti.Content;
        if(content is CornTab cornTab)
        {
            //Do with 'cornTab' whatever you want
        }
	}
