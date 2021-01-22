    void inner_menuitem_Can_Close(object sender, EventArgs e)
    {
        ToolStripMenuItem castSender = (ToolStripMenuItem)sender;
        object owner = castSender.OwnerItem;
        while (owner is ToolStripMenuItem)
        {
            if (((ToolStripMenuItem)owner).Owner is ContextMenuStrip)
                ((ContextMenuStrip)((ToolStripMenuItem)owner).Owner).Close();
            owner = ((ToolStripMenuItem)owner).OwnerItem;
        }
    }
