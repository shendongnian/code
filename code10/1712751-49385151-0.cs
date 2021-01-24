    var t = new List<Test>();
    foreach (var item in t.GroupBy(x => x.A))
    {
      A.MyList.Add(item);
    }
    
----------------
    public static class A
    {
        public static List<IGrouping<string, Test>> MyList { get; set; }
    }
