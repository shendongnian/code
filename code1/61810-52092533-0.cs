    SPList list = web.Lists["DemoDelete"];
    
    SPListItemCollection collListItems = list.GetItems();
    var watch = System.Diagnostics.Stopwatch.StartNew();
    Console.WriteLine("Start Time: " + watch);
    //delete all items uncomment this code
    //foreach (SPListItem item in collListItems)
    //{
    //    SPListItem delItem = list.GetItemById(item.ID);
    //    Console.WriteLine("Item Deleted" + delItem.ID);
    //    delItem.Delete();
    //    list.Update();
    //}
    //skip lastest 150 items
    for (int i = collListItems.Count - 150; i >= 0; i--)
    {
    SPListItem listItem = list.GetItemById(collListItems[i].ID);  //collListItems[i];
    Console.WriteLine("Item Deleted" + listItem.ID);
    listItem.Delete();
    list.Update();
    }
    
    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;
    Console.WriteLine("End Time: " + elapsedMs);
