    public static PlaylistCollection ToPlaylistCollection(this IEnumerable<Playlist> enumerable) {
      var list = new PlaylistCollection();
      foreach ( var item in enumerable ) {
        list.Add(item);
      }
      return list;
    }
