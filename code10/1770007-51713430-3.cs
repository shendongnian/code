     public void AddSong(SongData song)
        {
            SongItem songItem = new SongItem { SongData = song };
            songItem.FavoriteWasClicked += List_FavoriteWasClicked; ()
            this.Controls.Add(songItem);
        }
