    public static class VisualTreeHelperExtensions
	{
		public static IEnumerable<T> FindChild<T>(DependencyObject parent, string childName)
			where T : DependencyObject
		{
			// Confirm parent and childName are valid. 
			if (parent == null)
			{
				yield break;
			}
			int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
			for (int i = 0; i < childrenCount; i++)
			{
				var child = VisualTreeHelper.GetChild(parent, i);
				// If the child is not of the request child type child
				T childType = child as T;
				if (childType == null)
				{
					// recursively drill down the tree
					foreach (var innerChild in FindChild<T>(child, childName))
					{
						yield return innerChild;
					}
				}
				else if (!string.IsNullOrEmpty(childName))
				{
					var frameworkElement = child as FrameworkElement;
					// If the child's name is set for search
					if (frameworkElement != null && frameworkElement.Name == childName)
					{
						// if the child's name is of the request name
						yield return (T)child;
					}
				}
				else
				{
					// child element found.
					yield return (T)child;
				}
			}
		}
	}
