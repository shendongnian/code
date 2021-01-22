    private void ListView_MouseMove(object sender, MouseEventArgs e)
    {
        ListViewItem item = (sender as ListView).GetItemAt(e.X, e.Y);
        if (item != null)
        {
            // do something     
        }
    }
