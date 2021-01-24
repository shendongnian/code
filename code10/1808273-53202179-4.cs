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
		if (obj is ContentElement ce)
		{
			var parent = ContentOperations.GetParent(ce);
			if (parent != null)
				return parent;
			if (obj is FrameworkContentElement fe)
				return fe.Parent;
			return null;
		}
		return VisualTreeHelper.GetParent(obj);
	}
