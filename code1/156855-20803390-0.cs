    private void MenuStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
    {
        if (e.Item.Text == "")
        {
            e.Item.Visible = false;
        }
    }
