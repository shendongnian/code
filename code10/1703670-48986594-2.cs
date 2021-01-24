    for (int i = 0; i < ListBox1.Items.Count; i++)
    {
        var item = ListBox1.Items[i];
        
        if (item.Value == "value") // or item.Text  if you like
        {
            ListBox1.Items[i].Selected = true;
        }
    }
}
