    public static class SortColumn
    {
        public static readonly Func<Song, string> Artist = x => x.Artist;
        public static readonly Func<Song, string> Album = x => x.Album;
    }
