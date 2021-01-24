    public static T FindVisualChild<T>(DependencyObject parent)
		where T : DependencyObject
	{
		for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
		{
			DependencyObject childObject = VisualTreeHelper.GetChild(parent, i);
			if (childObject == null) return null;
			if (childObject is T obj)
			{
				return obj;
			}
			else
			{
				return FindVisualChild<T>(childObject);
			}
		}
		return null;
	}
