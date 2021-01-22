    item.Tag = Announcements[i].LastChild.InnerText;
    public void item_click(object sender, EventArgs e)
    {
        var menu = sender as ToolStripMenuItem;
        if (menu!= null)
            MessageBox.Show(menu.Tag);
    }
