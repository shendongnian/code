    public void FavoriteWasClicked(object sender, EventArgs e) {
            if (sender is SongItem)
            {
                songList2.AddSong(((SongItem)sender).SongData);
            }
        }
