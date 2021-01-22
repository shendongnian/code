    private void clbFolders_KeyUp(object sender, KeyEventArgs e) { Update(); }
    private void clbFolders_MouseUp(object sender, MouseEventArgs e) { Update(); }
    private void Update()
    {
        btnDelete.Enabled = clbFolders.CheckedItems.Count > 0;
    }
