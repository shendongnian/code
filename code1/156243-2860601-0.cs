    public class AlbumList : IEnumerable<Album>
    {
      public IEnumerator<Album> GetEnumerator()
      {
        foreach (Album item in internalStorage)
        {
          // You could use conditional checks or other statements here for a higher
          // degree of control regarding what the enumerator returns.
          yield return item;
        }
      }
    }
