    public class data
    {
         public string attribute1 { get; set; }
         public string attribute2 { get; set; }
         public string attribute3 { get; set; }
         public object myAttribute { get; set; }
    }
    _list.OrderBy(x => x.myAttribute).ToList();
