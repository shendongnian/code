    class Foo
    {
        public DateTime Month { get; set; }
        public int Count { get; set; }
    }
    List<Foo> months = new List<Foo>
    {
        new Foo{ Month = new DateTime(2010, 1, 1), Count = 3 },
        new Foo{ Month = new DateTime(2010, 2, 1), Count = 4 },
        new Foo{ Month = new DateTime(2010, 4, 1), Count = 2 },
        new Foo{ Month = new DateTime(2010, 5, 1), Count = 2 },
        new Foo{ Month = new DateTime(2010, 8, 1), Count = 3 },
        new Foo{ Month = new DateTime(2010, 9, 1), Count = -3 },
        new Foo{ Month = new DateTime(2010, 10, 1), Count = 6 },
        new Foo{ Month = new DateTime(2010, 11, 1), Count = 3 },
        new Foo{ Month = new DateTime(2010, 12, 1), Count = 7 },
        new Foo{ Month = new DateTime(2011, 2, 1), Count = 3 }
    };
