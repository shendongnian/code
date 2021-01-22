    listBox_Usernames.ContextMenuStrip = contextMenuStripRemove;
    listBox_Usernames.MouseUp += new MouseEventHandler(listBox_Usernames_MouseUp);
    void listBox_Usernames_MouseUp(object sender, MouseEventArgs e)
    {
        int index = listBox_Usernames.IndexFromPoint(e.Location);
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            if (index != ListBox.NoMatches)
            {
                if (listBox_Usernames.SelectedIndex == index)
                {
                    listBox_Usernames.ContextMenuStrip.Visible = true;
                }
                else
                {
                    listBox_Usernames.ContextMenuStrip.Visible = false;
                }
            }
            else
            {
                listBox_Usernames.ContextMenuStrip.Visible = false;
            }
        }
        else
        {
            listBox_Usernames.ContextMenuStrip.Visible = false;
        }
    }
