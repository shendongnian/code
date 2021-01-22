    static void Main(string[] args)
    {
        var g = XDocument.Parse("<nodes><skus><sku>abc</sku><sku>def123</sku></skus></nodes>");
        var t = from e in g.Descendants("sku")
        select e;
    }
