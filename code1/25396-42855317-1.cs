    IList<ListItem> illi = new List<ListItem>();
	ListItem li = null;
	foreach (HroCategory value in listddlsubcategory)
	{
		listddlsubcategoryext = server.getObjectListByColumn(typeof(HroCategory), "Parentid", value.Id);
		li = new ListItem();
		li.Text = value.Description;
		li.Value = value.Id.ToString();
		illi.Add(li);
		IList<ListItem> newilli = new List<ListItem>();
		newilli = SubCatagoryFunction(listddlsubcategoryext, "-->");
		foreach (ListItem c in newilli)
		{
			illi.Add(c);
		}
	}
