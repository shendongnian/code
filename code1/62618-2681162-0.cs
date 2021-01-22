    private static IEnumerable<DependencyObject> FindInVisualTreeDown(DependencyObject obj, Type type)
	{
		if (obj != null)
		{
			if (obj.GetType() == type)
			{
				yield return obj;
			}
			for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
			{
				foreach (var child in FindInVisualTreeDown(VisualTreeHelper.GetChild(obj, i), type))
				{
					if (child != null)
					{
						yield return child;
					}
				}
			}
		}
		yield break;
	}
