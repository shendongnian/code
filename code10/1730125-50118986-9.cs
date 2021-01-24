    var list = new Node("AAA");
    list = list.Add("AAAAA");
    list = list.Add("A");
    list = list.Add("AAAA");
    list = list.Add("AAAAAA");
    list = list.Add("AA");
    // max has the longest string
    var max = list.Aggregate(string.Empty, 
              (bookmark, item) => item.Length>bookmark.Length ? item : bookmark);
