    ContextMenuStrip ContextMenuStrip1 = new ContextMenuStrip();
    var item = ContextMenuStrip1.Items.Add("this is an item");
    item.BackColor = Color.FromArgb(255, 179, 179);
    item.Name = "key";
           
    int i = ContextMenuStrip1.Items.IndexOfKey("key");
    Color c = ContextMenuStrip1.Items[i].BackColor;
    
