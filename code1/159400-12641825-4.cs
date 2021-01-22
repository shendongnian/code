	private static bool IsUserVisible(FrameworkElement element, FrameworkElement container)
	{
		if (!element.IsVisible)
			return false;
		Rect bounds =
			element.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
		var rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
		return rect.Contains(bounds.TopLeft) || rect.Contains(bounds.BottomRight);
	}
