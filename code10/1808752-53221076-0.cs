      // Data generation
      var items = new List<Item>();
      for (int i = 0; i < 7; i++)
        items.Add(new Item() { Id = i + 1, Dt = DateTime.Parse("9/11/2018 14:00:00").AddMinutes(i), Name = "A1", Status = true });
      items[3].Name = "A2";
      items[4].Name = "A3";
      items[5].Status = false;
      // It's also good to make sure that elements are in correct order
      items = items.OrderBy(i => i.Dt).ToList();
      // Procedure, to execute your logic
      for (int i = 0; i < items.Count(); i++)
      {
        // If it has Status = true, then look for "enclosing" element with Status = false
        if(items[i].Status)
          for (int j = i + 1; j < items.Count(); j++)
          {
            if(!items[j].Status && items[j].Name == items[i].Name)
            {
              // Mark items, so we delete them (and recognize those with status 0 as used
              items[i].Name = "";
              items[j].Name = "";
            }
          }
      }
      // Remove all marked elements
      items.RemoveAll(i => i.Name == "");
