    // for performance tests..
    DateTime startDateTime;
    // create 2 lists  (master/child list)
    List<Item> itemList = new List<Item>();
    List<ItemDetails> itemDetailList = new List<ItemDetails>();
    Debug.WriteLine("# Adding items");
    startDateTime = DateTime.Now;
    
    // add items (sorted)
    for (int i = 0; i < 400000; i++)
        itemList.Add(new Item(i));
    // show how long it took
    Debug.WriteLine("Total milliseconds: " + (DateTime.Now - startDateTime).TotalMilliseconds.ToString("0") + "ms" );
    // adding some random details (also sorted)
    Debug.WriteLine("# Adding itemdetails");
    Random rnd = new Random(DateTime.Now.Millisecond);
    
    startDateTime = DateTime.Now;
    
    int index = 0;
    for (int i = 0; i < 800000; i++)
    {
        // when the random number is bigger than 2, index will be increased by 1
        index += rnd.Next(5) > 2 ? 1 : 0;
        itemDetailList.Add(new ItemDetails(index));
    }
    Debug.WriteLine("Total milliseconds: " + (DateTime.Now - startDateTime).TotalMilliseconds.ToString("0") + "ms");
    // show how many items the lists contains
    Debug.WriteLine("ItemList Count: " + itemList.Count());
    Debug.WriteLine("ItemDetailList Count: " + itemDetailList.Count());
    // matching items
    Debug.WriteLine("# Matching items");
    startDateTime = DateTime.Now;
    int itemIndex = 0;
    int itemDetailIndex = 0;
    int itemMaxIndex = itemList.Count;
    int itemDetailMaxIndex = itemDetailList.Count;
    // while we didn't reach any end of the lists, continue...
    while ((itemIndex < itemMaxIndex) && (itemDetailIndex < itemDetailMaxIndex))
    {
        // if the detail.parentid matches the item.id. add it to the list.
        if (itemList[itemIndex].Id == itemDetailList[itemDetailIndex].ParentId)
        {
            itemList[itemIndex].AddItemDetail(itemDetailList[itemDetailIndex]);
            // increase the detail index.
            itemDetailIndex++;
        }
        else
            // the detail.parentid didn't matches the item.id so check the next 1
            itemIndex++;
    }
    Debug.WriteLine("Total milliseconds: " + (DateTime.Now - startDateTime).TotalMilliseconds.ToString("0") + "ms");
