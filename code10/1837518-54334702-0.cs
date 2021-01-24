    var list = "abcdef".ToCharArray().ToList();    
    var item = list.ElementAt(list.Count - 2);
    list.RemoveAt(list.Count - 2);
    list.Insert(1, item);
    var reordered = string.Join(string.Empty, list);
    
