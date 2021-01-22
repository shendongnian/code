    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 1000; i++)
        {
            listView1.Items.Add(new ListViewItem("Item " + i));
        }
    
        _firstItemBounds = listView1.Items[0].Bounds;
    }
