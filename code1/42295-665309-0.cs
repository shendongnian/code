    private void DoLB2Selection()
    {
       // Loop through all items the ListBox.
       for (int x = 0; x < listBox1.Items.Count; x++)
       {
          // Determine if the item is selected.
          if(listBox1.GetSelected(x) == true)
             // Deselect all items that are selected.
             listBox2.SetSelected(x,true);
       }
