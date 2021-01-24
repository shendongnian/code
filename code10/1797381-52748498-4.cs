    private static void Example()
    {
        var myList = new List<Item>
        {
            new Item {ItemID = 1, Date = DateTime.Parse("10/10/2018 11:30 AM") },
            new Item {ItemID = 1, Date = DateTime.Parse("10/10/2018 11:32 AM") },
            new Item {ItemID = 1, Date = DateTime.Parse("10/10/2018 11:33 AM") },
            new Item {ItemID = 1, Date = DateTime.Parse("10/10/2018 11:34 AM") },
            new Item {ItemID = 1, Date = DateTime.Parse("10/10/2018 11:57 AM") },
            new Item {ItemID = 2, Date = DateTime.Parse("10/10/2018 7:45 AM") },
            new Item {ItemID = 2, Date = DateTime.Parse("10/10/2018 7:49 AM") },
            new Item {ItemID = 3, Date = DateTime.Parse("10/10/2018 8:45 AM") },
            new Item {ItemID = 3, Date = DateTime.Parse("10/10/2018 9:13 AM") }
        };
        Item baseItem = myList.First();
        int currentGroup = 1;
        // output first group
        Console.WriteLine($"Group {currentGroup}");
        foreach (var item in myList) // .OrderBy(i=>i.ItemID).ThenBy(i => i.Date))
        {
            // if item is different OR date is >5mins from the first
            if (item.ItemID != baseItem.ItemID || item.Date > baseItem.Date.AddMinutes(5))
            {
                // different group
                currentGroup += 1;
                // set new base item
                baseItem = item;
                Console.WriteLine($"\nGroup {currentGroup}");// output new group
            }
            // output the item
            Console.WriteLine($"Item {item.ItemID}. Date: {item.Date}");
        }
    }
