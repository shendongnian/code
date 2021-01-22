      [WebMethod]
      public List<Artist> ListAllArtists()
      {
          List<Artist> all = new List<Artist>();
          Album one = new Album { Name = "hi", SongNames = new List<string> { "foo", "bar", "baz" } };
          Album two = new Album { Name = "salut", SongNames = new List<string> { "green", "orange", "red" } };
          Album three = new Album { Name = "hey", SongNames = new List<string> { "brown", "pink", "blue" } };
          Album four = new Album { Name = "hello", SongNames = new List<string> { "apple", "orange", "pear" } };
    
          all.Add(new Artist { Albums = new List<Album> { one }, Name = "Mr Guy" });
          all.Add(new Artist { Albums = new List<Album> { two }, Name = "Mr Buddy" });
          all.Add(new Artist { Albums = new List<Album> { three, four }, Name = "Mr Friend" });
        
          return all;        
      }
    public class Artist
    {
        public List<Album> Albums;
        public string Name;
    }
    public class Album
    {
        public string Name;
        public List<string> SongNames;
    }
