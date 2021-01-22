    var query = yourData
                .GroupBy(x => new { x.Vol, x.Component, x.Dwg, x.View })
                .Select(x => x.First());
    // and to test...
    foreach (var x in query)
    {
        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
            x.Vol, x.Component, x.Dwg, x.View, x.Revision ?? "NULL");
    }
    // Volume U01    Composed Drawings    SJTest    1    B
    // Volume U03    Composed Drawings    SJTest    3    NULL
