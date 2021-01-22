        private string name = string.Empty;
        private void lstNames_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstNames.Items.Count == 0)
                name = string.Empty;
            else
            {
                int index = lstNames.IndexFromPoint(e.X, e.Y);
                name = lstNames.Items[index].ToString();
            }
        }
        private void lstNames_MouseUp(object sender, MouseEventArgs e)
        {
            if (name != string.Empty)
                CalendarControl_DblClick(name, null);
        }
