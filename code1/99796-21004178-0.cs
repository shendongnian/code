            // Create dictionary.. Can be done somewhere else..
            var dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Item 1");
            dictionary.Add(2, "Item 2");
            // You can set up the column in the designer as well.
            objectListView1.Columns.Add(new OLVColumn(title: "Items", aspect: "Value"));
            // Initially tells OLV to use the dictionary as a datasource.
            objectListView1.SetObjects(dictionary);
            // .....
            // Later on, you can add another item to the dictionary.
            dictionary.Add(3, "Item 3");
            // All you have to do now, is call .BuildList(), and your listview is updated.
            // shouldPreserveState can be false if you want. I want it to be true. :)
            objectListView1.BuildList(shouldPreserveState:true);
