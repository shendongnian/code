    static void Main()
    {
        var objs = new[]
        {
            new Relationship { ID = "a", RelatedID = "b" }, // <----\
            new Relationship { ID = "a", RelatedID = "c" }, //      |
            new Relationship { ID = "a", RelatedID = "b" }, // dup--/
            new Relationship { ID = "d", RelatedID = "b" }, // <------\
            new Relationship { ID = "d", RelatedID = "c" }, //        |
            new Relationship { ID = "d", RelatedID = "b" }, // dup ---/ 
            new Relationship { ID = "b", RelatedID = "c" }, //
        };
        var count = objs.Distinct(new IdEqualityComparer()).Count();
        System.Console.WriteLine(count);
    }
