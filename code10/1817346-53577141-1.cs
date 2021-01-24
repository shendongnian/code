	private void calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		DependencyObject originalSource = e.OriginalSource as DependencyObject;
		CalendarDayButton day = FindParentOfType<CalendarDayButton>(originalSource);
		if (day != null)
		{
			//open menu
		}
	}
	//and you will need this helper method
	//generally a staple in any WPF programmer's arsenal
	public static T FindParentOfType<T>(DependencyObject source) where T : DependencyObject
	{
		T ret = default(T);
		DependencyObject parent = VisualTreeHelper.GetParent(source);
		if (parent != null)
		{
			ret = parent as T ?? parent.FindParentOfType<T>() as T;
		}
		return ret;
	}
