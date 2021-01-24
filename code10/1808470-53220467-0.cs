	void DataGridPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		e.Handled = true;
		var result = VisualTreeHelper.HitTest(gd, e.GetPosition(gd));
		var row = DependencyObjectHelper.FindAncestor<DataGridRow>(result.VisualHit);
		if (row != null && !row.IsSelected)
			row.IsSelected = true;
	}
