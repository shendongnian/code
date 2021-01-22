    var groups = from result in query
                 group result by new { result.ProductId } into g
                 select g;
    foreach(var group in groups) {
        Console.Write("{0}: ", group.Key.ProductId);
        Console.WriteLine(String.Join("/", group.Select(p => String.Format("{0}, {1:0.0}", p.Description, p.Cost)).ToArray()));
    }
