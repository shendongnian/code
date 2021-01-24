	var filteredList = listOfAnimal
		.Where(d =>
			   {
				   string name;
				   if (!d.TryGetValue("name", out name))
					   // Include the dictionary if it completely lacks a "name" entry.
					   return true;
				   // Include the dictionary if the "name" entry is something other than "Ant".
				   return name != "Ant";
			   })
		.ToList();
