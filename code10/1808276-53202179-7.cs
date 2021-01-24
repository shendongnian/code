	public static T FindAncestor<T>(DependencyObject obj)
		where T : DependencyObject
	{
		if (obj != null)
		{
			var dependObj = obj;
			do
			{
				dependObj = GetParent(dependObj);
				if (dependObj is T)
					return dependObj as T;
			}
			while (dependObj != null);
		}
		return null;
	}
	public static DependencyObject GetParent(DependencyObject obj)
	{
		if (obj == null)
			return null;
		if (obj is ContentElement)
		{
			var parent = ContentOperations.GetParent(obj as ContentElement);
			if (parent != null)
				return parent;
			if (obj is FrameworkContentElement)
				return (obj as FrameworkContentElement).Parent;
			return null;
		}
		return VisualTreeHelper.GetParent(obj);
	}
