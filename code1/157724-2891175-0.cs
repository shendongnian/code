    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
          ListView.SelectedIndexCollection sel = listView1.SelectedIndices;
    
          if (sel.Count == 1)
          {
              ListViewItem selItem = listView1.Items[sel[0]];
              textBox1.Text = selItem.SubItems[1].Text;
          }
    }
