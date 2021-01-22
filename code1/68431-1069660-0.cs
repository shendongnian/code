    var indices = new List<int>();
    
    for(int i = 0; i < lstVariable_All.Items.Count; i++)
    {
      // If this item meets our selection criteria 
      if( lstVariable_All.Items[i].Text.Contains("foo") )
        indices.Add(i);
    }
    
    // Reset the selection and add the new items.
    lstVariable_All.SelectedIndices.Clear();
    
    foreach(int index in indices)
    {
      lstVariable_All.SelectedIndices.Add(index);
    }
