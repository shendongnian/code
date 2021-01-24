    List<DataRow> duplicates = CollectionIn.AsEnumerable()
		.GroupBy(r => r.Field<string>("Folder"))
		.Where(g => g.Count() > 1)
		.SelectMany(grp => grp)
		.ToList();
	duplicates.ForEach(CollectionIn.Rows.Remove);
