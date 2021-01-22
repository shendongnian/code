    private void AddColumnsContextMenu_Click(object sender, RoutedEventArgs e)
    {
        MenuItem mi = e.Source as MenuItem;
        string title = mi.Header.ToString();
        MessageBox.Show("Selected"+title);
    }
