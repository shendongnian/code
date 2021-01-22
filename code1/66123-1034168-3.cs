    private Point myMousePlacementPoint;
    private void OnListViewMouseDown(object sender, MouseButtonEventArgs e)
	{
		if (e.MiddleButton == MouseButtonState.Pressed)
		{
			myMousePlacementPoint = this.PointToScreen(Mouse.GetPosition(this));
		}
	}
	private void OnListViewMouseMove(object sender, MouseEventArgs e)
	{
		ScrollViewer scrollViewer = ScrollHelper.GetScrollViewer(uiListView) as ScrollViewer;
		if (e.MiddleButton == MouseButtonState.Pressed)
		{
			var currentPoint = this.PointToScreen(Mouse.GetPosition(this));
			if (currentPoint.Y < myMousePlacementPoint.Y)
			{
				scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - 3);
			}
			else if (currentPoint.Y > myMousePlacementPoint.Y)
			{
				scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + 3);
			}
			if (currentPoint.X < myMousePlacementPoint.X)
			{
				scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - 3);
			}
			else if (currentPoint.X > myMousePlacementPoint.X)
			{
				scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + 3);
			}
		}
	}
    public static DependencyObject GetScrollViewer(DependencyObject o)
	{
		// Return the DependencyObject if it is a ScrollViewer
		if (o is ScrollViewer)
		{ return o; }
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
		{
			var child = VisualTreeHelper.GetChild(o, i);
			var result = GetScrollViewer(child);
			if (result == null)
			{
				continue;
			}
			else
			{
				return result;
			}
		}
		return null;
	}
