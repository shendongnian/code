    private ListViewItem GetItemFromPoint(ListView listView, Point mousePosition)
    {
        // translate the mouse position from screen coordinates to 
        // client coordinates within the given ListView
        Point localPoint = listView.PointToClient(mousePosition);
        return listView.GetItemAt(localPoint.X, localPoint.Y);
    }
    // call it like this:
    ListViewItem item = GetItemFromPoint(myListView, Cursor.Position);
