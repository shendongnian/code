    public class Foo
    {
        public int FooID { get; set; }
        public DateTime FooDate { get; set; }
    }
...
    List<Foo> foos = new List<Foo>()
    {
        new Foo() { FooID = 1, FooDate = new DateTime(2010,3,15,18,30,0)},
        new Foo() { FooID = 2, FooDate = new DateTime(2010,3,15,19,30,0)},
        new Foo() { FooID = 3, FooDate = new DateTime(2010,3,15,20,30,0)},
        new Foo() { FooID = 4, FooDate = new DateTime(2010,3,15,18,15,0)},
        new Foo() { FooID = 5, FooDate = new DateTime(2010,3,15,18,45,0)},
        new Foo() { FooID = 6, FooDate = new DateTime(2010,3,15,20,15,0)},
        new Foo() { FooID = 7, FooDate = new DateTime(2010,3,15,19,15,0)}
    };
    
    var query = from foo in foos
                group foo by foo.FooDate.Hour
                    into foogroup
                    select new
                    {
                        Date = foogroup.Key,
                        Foos = foos.Where(foo => foo.FooDate.Hour == foogroup.Key)
                    };
    
    foreach (var group in query)
    {
        Console.WriteLine(group.Date);
        foreach (Foo foo in group.Foos)
            Console.WriteLine("\t{0}\t{1}", foo.FooID, foo.FooDate);
    }
