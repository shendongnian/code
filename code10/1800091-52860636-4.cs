	var filteredList = listOfAnimal
		.Where(d =>
			   {
				   string name;
				   if (!d.TryGetValue("name", out name))
					   // Exclude the dictionary if it completely lacks a "name" entry.
					   return false;
				   // Include the dictionary if the "name" entry equals "Ant".
				   return name == "Ant";
			   })
		.ToList();
