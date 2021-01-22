    bool isRunAtStartupClicked;
    private void ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {   
        if (e.ClickedItem == trayIcon.ContextMenuStrip.Items["miRunAtStartup"])
        {   
            isRunAtStartupClicked = true;
        }
    }
    
    private void ContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
    {   
        if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
        {   
            if (isRunAtStartupClicked)
            {   
                isRunAtStartupClicked = false;
                e.Cancel = true;
            }
        }
    }
