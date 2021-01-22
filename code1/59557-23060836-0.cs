	/// <summary>
	/// Get the object from the selected listview item.
	/// </summary>
	/// <param name="LV"></param>
	/// <param name="originalSource"></param>
	/// <returns></returns>
	private object GetListViewItemObject(ListView LV, object originalSource)
	{
		DependencyObject dep = (DependencyObject)originalSource;
		while ((dep != null) && !(dep.GetType() == typeof(ListViewItem)))
		{
			dep = VisualTreeHelper.GetParent(dep);
		}
		if (dep == null)
			return null;
		object obj = (Object)LV.ItemContainerGenerator.ItemFromContainer(dep);
		return obj;
	}
	private void lvFiles_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		object obj = ListViewHelper.GetListViewItemObject(lvFiles, e.OriginalSource);
		if (obj.GetType() == typeof(MyObject))
		{
			MyObject MyObject = (MyObject)obj;
			// Add the rest of your logic here.
		}
	}		
