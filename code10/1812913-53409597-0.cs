	var result = new List<SubItem>(); //list of combined SubItems
	var ms = 0; // start index of items from list to combine
	var mk = 0; // end index of items from list to combine
	for (int i = 0; i < components.Count; i++) // count of all items
	{
		if (i == 0) //if there is a first item then we don't combine codes and prices
		{
			for (int mat = 0; mat < components[i].SubItems.Count; mat++)
			{
				var data = components[i].SubItem[mat];
				result.Add(new SubItem { Price = data.Price, Code = data.Code });
				mk = mat; // set last index of SubItem to combine
			}
			continue;
		}
		for (int j = ms; j < mk + 1; j++) // iterate from first to last SubItem to combine them with new SubItems 
		{
			for (int mat = 0; mat < components[i].SubItems.Count; mat++) // iterate through SubItems
			{
				result.Add(new SubItem { Code = result[j].Code + ":" + components[i].SubItem[mat].Code, price = result[j].Price + components[i].SubItem[mat].Price }); // Combine last SubItem with now iterating Subitem.
			}
		}
		ms = mk + 1; // update new start index to combine
		mk = result.Count - 1; // update new end index to combine
	}
