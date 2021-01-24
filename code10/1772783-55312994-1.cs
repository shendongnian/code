    public static void UndoDBChanges(System.Data.Linq.DataContext dataContext) {
	var changeSet = dataContext.GetChangeSet();
	if (changeSet != null)
	{
		var updates = changeSet.Updates.ToArray();
		dataContext.Refresh(RefreshMode.OverwriteCurrentValues, changeSet.Updates);
		foreach (var o in updates)
		{
			try
			{
				Type t = o.GetType();
				dynamic obj = Convert.ChangeType(o, t);
				foreach (System.Reflection.PropertyInfo prop in t.GetProperties())
				{
					obj.SendPropertyChangedFromOutside(prop.Name);
				}
			}
			catch
			{ }
		}
	}}
