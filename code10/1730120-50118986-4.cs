    var list = new List<string>();
    list.Add("AAA");
    list.Add("AAAAA");
    list.Add("A");
    list.Add("AAAA");
    list.Add("AAAAAA");
    list.Add("AA");
    // max has the longest string
    var max = list.Aggregate(string.Empty, 
              (bookmark, item) => item.Length>bookmark.Length ? item : bookmark);
     
