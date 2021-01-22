    private void DataBoundMenuItem_Click(object sender, RoutedEventArgs e)
    {
       MenuItem obMenuItem = e.OriginalSource as MenuItem;
       MessageBox.Show( String.Format("{0} just said Hi!", obMenuItem.Header));
    }
