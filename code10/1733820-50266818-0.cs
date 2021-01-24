	//list is your data collection
	//newlist is the result
	var newlist = new List<dynamic>();
	list.ForEach(w =>
	{
		newlist.Add(
			new {w.ProductID,DataType="Percent",Value=w.Percent,w.RowIndex}
		);
		newlist.Add(
			new {w.ProductID,DataType="Name",Value=w.Name,w.RowIndex}
		);
	});
	newlist.Dump();
