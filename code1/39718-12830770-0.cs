    int topItemIndex = 0;
    try
    {
         topItemIndex = listView1.TopItem.Index;
    }
    catch (Exception ex)
    { }
    listView1.BeginUpdate();
    listView1.Items.Clear();
    //CODE TO FILL LISTVIEW GOES HERE
    listView1.EndUpdate();
    try 
    { 
        listView1.TopItem = listView1.Items[topItemIndex];
    }
    catch (Exception ex)
    { }
