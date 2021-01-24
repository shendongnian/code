	/// <summary>
	/// Returns a first ancestor of the provided type.
	/// </summary>
	public static Visual GetAncestorOfType(this Visual element, Type type)
	{
		if (element == null)
			return null;
		if (type == null)
			throw new ArgumentException(nameof(type));
		(element as FrameworkElement)?.ApplyTemplate();
		if (!(VisualTreeHelper.GetParent(element) is Visual parent))
			return null;
		return type.IsInstanceOfType(parent) ? parent : GetAncestorOfType(parent, type);
	}
	/// <summary>
	/// Returns a first ancestor of the provided type.
	/// </summary>
	public static T GetAncestorOfType<T>(this Visual element)
		where T : Visual => GetAncestorOfType(element, typeof(T)) as T;
