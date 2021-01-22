 C#
public static IEnumerable<T> GetDescendants<T>(T parent) where T : DependencyObject
{
	if (parent == null)
		yield break;
	var descendants = new Queue<DependencyObject>();
	descendants.Enqueue(parent);
	while (descendants.Any())
	{
		var currentDescendant = descendants.Dequeue();
        (currentDescendant as FrameworkElement)?.ApplyTemplate();
		for (var i = 0; i < VisualTreeHelper.GetChildrenCount(currentDescendant); i++)
		{
			var child = VisualTreeHelper.GetChild(currentDescendant, i);
			descendants.Enqueue(child);
			if (child is T foundObject)
				yield return foundObject;
		}
	}
}
This will be useful e.g. if you are looking for the nearest child element of some type and condition:
 C#
var foundElement = GetDescendants<StackPanel>(someElement)
                       .FirstOrDefault(o => o.SomeProperty == SomeState);
