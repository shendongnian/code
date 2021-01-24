    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
       if (listView1.SelectedItems.Count < 1) return; 
       var item = listView1.SelectedItems[0]; 
       listView2.Items.Add( (ListViewItem) item.Clone()); 
    }
