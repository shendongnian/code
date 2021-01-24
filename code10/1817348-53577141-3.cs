    <Calendar x:Name="calendar" Grid.Column="1" HorizontalAlignment="Stretch"
              Margin="10,7,0,0" VerticalAlignment="Top" IsTodayHighlighted="True" 
              MouseDoubleClick="calendar_MouseDoubleClick">
	private void calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		DependencyObject originalSource = e.OriginalSource as DependencyObject;
		CalendarDayButton day = FindParentOfType<CalendarDayButton>(originalSource);
		if (day != null)
		{
			//open menu
		}
        e.Handled = true;
	}
	//and you will need this helper method
	//generally a staple in any WPF programmer's arsenal
	public static T FindParentOfType<T>(DependencyObject source) where T : DependencyObject
	{
		T ret = default(T);
		DependencyObject parent = VisualTreeHelper.GetParent(source);
		if (parent != null)
		{
			ret = parent as T ?? FindParentOfType<T>(parent) as T;
		}
		return ret;
	}
