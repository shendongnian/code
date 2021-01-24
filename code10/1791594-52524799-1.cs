    var list = new List<Fuse>()
    {
        new Fuse{Designator = "F8,F9"},
        new Fuse{Designator = "F1,F2,F3"},
        new Fuse{Designator = "F10-F12"},
        new Fuse{Designator = "F4-F7"},
    };
    foreach (var itm in list.OrderBy(_ => _))
    {
        Console.WriteLine(itm.Designator);
    }
    Console.ReadLine();
