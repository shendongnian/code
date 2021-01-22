 C#
public static IEnumerable<T> GetVisualDescendants<T>(DependencyObject parent, bool applyTemplates = false)
    where T : DependencyObject
{
	if (parent == null || !(child is Visual || child is Visual3D))
		yield break;
	var descendants = new Queue<DependencyObject>();
	descendants.Enqueue(parent);
	while (descendants.Count > 0)
	{
		var currentDescendant = descendants.Dequeue();
        if (applyTemplates)
            (currentDescendant as FrameworkElement)?.ApplyTemplate();
		for (var i = 0; i < VisualTreeHelper.GetChildrenCount(currentDescendant); i++)
		{
			var child = VisualTreeHelper.GetChild(currentDescendant, i);
            if (child is Visual || child is Visual3D)
                descendants.Enqueue(child);
			if (child is T foundObject)
				yield return foundObject;
		}
	}
}
The resulting elements will be ordered from nearest to farthest.
This will be useful e.g. if you are looking for the nearest child element of some type and condition:
 C#
var foundElement = GetDescendants<StackPanel>(someElement)
                       .FirstOrDefault(o => o.SomeProperty == SomeState);
