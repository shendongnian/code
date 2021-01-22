    class Foo
    {
        public int Id { get; set; }
        public int Bar { get; set; }
    }
...
    List<Foo> foos = new List<Foo>(); // populate somewhere
    Func<Foo, bool> where = f => f.Id > 0;
    Func<Foo, int> groupby = f => f.Id;
    Func<IGrouping<int, Foo>, int> orderby = g => g.Sum(f => f.Bar);
    Func<IGrouping<int, Foo>, FooDataItem> select = g => new FooDataItem { Key = g.Key, BarTotal = g.Sum(f => f.Bar) };
    var query = GetData(foos, where, groupby, orderby, select);
