    private static void RevealMoreItems(object sender, DragEventArgs e)
    {
        var listView = (ListView)sender;
        var point = listView.PointToClient(new Point(e.X, e.Y));
        var item = listView.GetItemAt(point.X, point.Y);
        if (item == null)
            return;
        var index = item.Index;
        var maxIndex = listView.Items.Count;
        var scrollZoneHeight = listView.Font.Height;
        if (index > 0 && point.Y < scrollZoneHeight)
        {
            listView.Items[index - 1].EnsureVisible();
        }
        else if (index < maxIndex && point.Y > listView.Height - scrollZoneHeight)
        {
            listView.Items[index + 1].EnsureVisible();
        }
    }
