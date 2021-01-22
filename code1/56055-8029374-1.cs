        void  listView_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView.GetItemAt(e.X, e.Y);
            ListViewHitTestInfo info = listView.HitTest(e.X, e.Y);
            if ((item != null) && (info.SubItem != null))
            {
                // Option #1 - Set it to the sub-item text
                // toolTip.SetToolTip(listView, info.SubItem.Text);
                // Option #2 - Sets it to the tool tip text of the sub-item
                toolTip.SetToolTip(listView, info.Item.ToolTipText);
            }
            else
            {
                toolTip.SetToolTip(listView, null);
            }
        }
