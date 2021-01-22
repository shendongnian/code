        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            //get the context menu (it holds the caller)
            ContextMenuStrip contextMenu = sender as ContextMenuStrip;
            //get the callers name for testing 
            string controlName = contextMenu.SourceControl.Name;
            
            //test if it is infact me rich text editor making the call.
            if (controlName == "text_rchtxt")
            {
                //if I have nothing selected... I should not be able to copy
                if (text_rchtxt.SelectedText == "")
                    copy_shrtct.Enabled = false; 
            }
            else
            {
                //if I do have something selected or if its another control making the call, enable copying
                copy_shrtct.Enabled = true;
            }
        }
        
