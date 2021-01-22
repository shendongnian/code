public static class MyExtensionMethods
	{
		public static void InitializeAppearance(this ListView aListView)
		{
			aListView.View = View.Details;
			aListView.AllowColumnReorder = true;
			aListView.CheckBoxes = false;
			aListView.FullRowSelect = true;
			aListView.GridLines = false;
			aListView.Sorting = SortOrder.Ascending;
		}
	}
}
and you call it listview1.InitializeAppearance();
