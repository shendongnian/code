    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        if (e.ColumnIndex == 0 && e.Item.Text=="1")
        {
            e.DrawBackground();
            e.DrawText();
        }
        else
        {
            e.DrawDefault = true;
        }
    }
    
    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }
