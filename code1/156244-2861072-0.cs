    public class Album
    {
        public readonly string Artist;
        public readonly string Title;
        public Album(string artist, string title)
        {
             Artist = artist;
             Title = title;
        } 
    }
    public class AlbumList
    {
        private List<Album> Albums = new List<Album>();
        public int Count
        {
            get { return Albums.Count; }
        }
        public Album this[int index]
        {
            get
            {
                return Albums[index];
            }
        }
        public Album this[string albumName]
        {
            get
            {
                return Albums.FirstOrDefault(c => c.Title == albumName);
            }
        }
        public void Add(Album album)
        {
            Albums.Add(album);
        }
        public void Remove(Album album)
        {
            Albums.Remove(album);
        }
    }
