    using System.Collections;
    using System.Collections.Generic;
    public class AlbumList : IEnumerable<Album>
    {
        private List<Album> Albums = new List<Album>();
        
        public int Count { get { return Albums.Count; } }
        public IEnumerator<Album> GetEnumerator()
        {
            return this.Albums.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
