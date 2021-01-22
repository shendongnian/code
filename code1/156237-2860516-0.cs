    public class AlbumList : IEnumerable<Album>
    {
        // ...
        public IEnumerator<Album> GetEnumerator()
        {
            return this.albums.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
