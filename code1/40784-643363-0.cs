    private void lstvPositions_DragDrop(object sender, DragEventArgs e)
    {
       var localPoint = lstvPositions.PointToClient(new Point(e.X, e.Y));
       var group = lstvPositions.GetItemAt(localPoint.X, localPoint.Y);
       var item = e.Data.GetData(DataFormats.Text).ToString();
       lstvPositions.Items.Add(new ListViewItem {Group = group.Group, Text = item});
    }
