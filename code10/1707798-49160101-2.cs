    var dashes = new String('-', 50);
    void WriteNodesBetween(XNode from, XNode to) {
        Console.WriteLine(dashes);
        var xn = from;
        for (; xn != to; xn = xn.NextNode)
            Console.Write(xn.ToString());
        Console.WriteLine(xn.ToString());
    }
