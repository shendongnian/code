    var Foo_Old = new[] { "test1", "test2", "test3" }; 
    var Foo_New = new[] { "test1", "test2", "test4", "test5" };
    
    var diff = Foo_New.Except( Foo_Old );
    var inter = Foo_New.Intersect( Foo_Old );
    var rem = Foo_Old.Except(Foo_New);
    
    foreach (var s in diff)
    {
        Console.WriteLine("Added " + s);
    }
    
    foreach (var s in inter)
    {
        Console.WriteLine("Same " + s);
    }
    
    foreach (var s in rem)
    {
        Console.WriteLine("Removed " + s);
    }
