        ListViewItem.ListViewSubItem SelectedLSI;
        private void listView2_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo i = listView2.HitTest(e.X, e.Y);
            SelectedLSI = i.SubItem;
            if (SelectedLSI == null)
                return;
            int border = 0;
            switch (listView2.BorderStyle)
            {
                case BorderStyle.FixedSingle:
                    border = 1;
                    break;
                case BorderStyle.Fixed3D:
                    border = 2;
                    break;
            }
            int CellWidth = SelectedLSI.Bounds.Width;
            int CellHeight = SelectedLSI.Bounds.Height;
            int CellLeft = border + listView2.Left + i.SubItem.Bounds.Left;
            int CellTop =listView2.Top + i.SubItem.Bounds.Top;
            // First Column
            if (i.SubItem == i.Item.SubItems[0])
                CellWidth = listView2.Columns[0].Width;
            TxtEdit.Location = new Point(CellLeft, CellTop);
            TxtEdit.Size = new Size(CellWidth, CellHeight);
            TxtEdit.Visible = true;
            TxtEdit.BringToFront();
            TxtEdit.Text = i.SubItem.Text;
            TxtEdit.Select();
            TxtEdit.SelectAll();
        }
        private void listView2_MouseDown(object sender, MouseEventArgs e)
        {
            HideTextEditor();
        }
        private void listView2_Scroll(object sender, EventArgs e)
        {
            HideTextEditor();
        }
        private void TxtEdit_Leave(object sender, EventArgs e)
        {
            HideTextEditor();
        }
        private void TxtEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                HideTextEditor();
        }
        private void HideTextEditor()
        {
            TxtEdit.Visible = false;
            if (SelectedLSI != null)
                SelectedLSI.Text = TxtEdit.Text;
            SelectedLSI = null;
            TxtEdit.Text = "";
        }
