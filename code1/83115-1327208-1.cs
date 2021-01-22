    for (int i = ListView1.Items.Count - 1; i >= 0; i--)
    {
      if (ListView1.Items[i].Checked)
      {
        ListView2.Add(ListView1.Items[i]);
      }
    }
    
    
    //Delete checked 
    ListView1.CheckedIndexCollection checkedItemsList = listView1.CheckedIndices;     
    while (checkedItemsList.Count > 0)
    {
       listView1.Items.RemoveAt(checkedItemsList[0]);
    }
