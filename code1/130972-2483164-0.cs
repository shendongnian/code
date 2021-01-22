       this.menuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing); 
    
    void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
                {
                    if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                    {
                        e.Cancel = true;
                        ((ToolStripDropDownMenu) sender).Invalidate();
                    } 
                }
