    private void listViewMasterVolt_DoubleClick(object sender, EventArgs e)
    {
        Point mousePosition = myListView.PointToClient(Control.MousePosition);
        ListViewHitTestInfo hit = myListView.HitTest(mousePosition);
        int columnindex = hit.Item.SubItems.IndexOf(hit.SubItem);
