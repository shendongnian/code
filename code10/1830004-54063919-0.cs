     foreach (ListViewItem item in listView1.Items)
     {
       item.SubItems[0].BackColor = Color.Green;
       item.SubItems[1].BackColor = Color.Blue;
       item.SubItems[2].BackColor = Color.Orange;
       item.UseItemStyleForSubItems = false;
     }
