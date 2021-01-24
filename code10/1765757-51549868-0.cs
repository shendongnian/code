    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selected = AlbumSongList.SelectedItem as Model;
        
        Debug.WriteLine("You have selected the song :Song Number is {0}, and Song is {1}",
            selected.SongNumber, selected.Song);
    }
