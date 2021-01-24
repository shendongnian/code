    private void ListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
       for (int i = 0; i < listView1.Items.Count; i++)
       {
          listView1.ItemSelectionChanged -= ListView1_ItemSelectionChanged;
          listView1.ItemCheck -= ListView1_ItemCheck;
          listView1.Items[i].Selected = listView1.Items[i].Checked;
          listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
          listView1.ItemCheck += ListView1_ItemCheck;
       }
     }
    
    private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
       for (int i = 0; i < listView1.Items.Count; i++)
       {
          listView1.ItemChecked -= ListView1_ItemChecked;
          listView1.ItemCheck -= ListView1_ItemCheck;
          listView1.Items[i].Checked = listView1.Items[i].Selected;
          listView1.ItemChecked += ListView1_ItemChecked;
          listView1.ItemCheck += ListView1_ItemCheck;
       }
     }
    
    private void ListView1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
       if (e.NewValue != CheckState.Unchecked) return;
       Point locaPoint = listView1.PointToClient(MousePosition);
       ListViewItem prevHoverdItem = listView1.GetItemAt(locaPoint.X, locaPoint.Y);
       if (prevHoverdItem == null) return;
       if (prevHoverdItem != listView1.Items[e.Index]) e.NewValue = CheckState.Checked;
    }
