    interface INews1BE
    {
        DateTime PublishedDate { get; set; }
    }
    class News1BE : INews1BE
    {
        public DateTime PublishedDate { get; set; }
    };
    
    class DateTimeAscendingComparer : IComparer<DateTime>
    {
        public int Compare(DateTime a, DateTime b)
        {
            return a.CompareTo(b);
        }
    };
    
    var c = new DateTimeAscendingComparer();
    var sl = new SortedList<DateTime, INews1BE>(c);
    
    var item1 = new News1BE() 
    {
        PublishedDate = DateTime.Now
    };
    
    var item2 = new News1BE()
    {
        PublishedDate = item1.PublishedDate.AddSeconds(-30)
    };
    
    sl.Add(item1.PublishedDate, item1);
    
    //item2 goes before item1
    sl.Add(item2.PublishedDate, item2);
    
    foreach(var x in sl)
    {
        Console.WriteLine(x.Key);
    }
