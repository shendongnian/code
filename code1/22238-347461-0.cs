        private void panel1_ParentChanged(object sender, EventArgs e)
        {
            Panel thisPanel = sender as Panel;
    
            if(thisPanel != null && thisPanel.Parent != null)
            {
                thisPanel.Parent.MouseEnter += delegate(object senderObj, EventArgs eArgs) { thisPanel.BackColor = SystemColors.Control; };
            }
        }
    
