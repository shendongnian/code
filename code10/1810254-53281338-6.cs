    private void BtnUpdateStream_Click(object sender, RoutedEventArgs e)
    {
        dynamic x = GridStream.SelectedItem;
        if (x != null)
        {
            int Id = x.streamid;
            //...
        }
    }
