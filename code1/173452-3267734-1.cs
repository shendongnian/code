      private void MyEventHandler(object sender, MouseButtonEventArgs e)
        {
            ListViewItem Item = (ListViewItem)sender;
            SongData Song = (SongData)Item.Content;
            // Example
            MessageBox.Show(Song.Title + " by " + Song.Artist);
            e.Handled = true;
        }
