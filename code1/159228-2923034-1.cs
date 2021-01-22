    private void ContextMenu_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
        ContextMenu contextMenu = sender as ContextMenu;
        Point p = e.GetPosition(contextMenu);
        contextMenu.IsOpen = p.X >= 0 && p.X <= contextMenu.ActualWidth && p.Y >= 0 && p.Y <= contextMenu.ActualHeight;
    }
