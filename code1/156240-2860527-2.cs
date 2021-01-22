    public class AlbumList
    {
        private List<Album> Albums = new List<Album>();
        
        public int Count { get { return Albums.Count; } }
        public IEnumerator<Album> GetEnumerator()
        {
            return this.Albums.GetEnumerator();
        }
    }
