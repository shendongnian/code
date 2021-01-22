    myListBox.ContextMenu.Popup += new EventHandler(myContextPopupHandler);
    private void myContextPopupHandler(Object sender, System.EventArgs e)
    {
        if (SelectedItem != null)
        {
            ContextMenu.MenuItems[1].Enabled = true;
            ContextMenu.MenuItems[2].Enabled = true;
        }
        else
        {
            ContextMenu.MenuItems[1].Enabled = false;
            ContextMenu.MenuItems[2].Enabled = false;
        }
    }
