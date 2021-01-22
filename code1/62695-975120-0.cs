    private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        //Make sure the sender is a ToolStripMenuItem
        ToolStripMenuItem myItem = sender as ToolStripMenuItem;
        if (myItem != null)
        {
            //Get the ContextMenuString (owner of the ToolsStripMenuItem)
            ContextMenuStrip theStrip = myItem.Owner as ContextMenuStrip;
            if (theStrip != null)
            {
                //The SourceControl is the control that opened the contextmenustrip.
                //In my case it could be a linkLabel
                LinkLabel linkLabel = theStrip.SourceControl as LinkLabel;
                if (linkLabel == null)
                    MessageBox.Show("Invalid item selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (MessageBox.Show(string.Format("Are you sure you want to remove BOL {0} from this Job?", linkLabel.Text), "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        linkLabel.Text = Program.NullValue(linkLabel);
                    }
                }
            }
        }
    }
