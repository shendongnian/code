    static void Main()
    {
        IEnumerable<Invoice> invoices = new List<Invoice>()
        { 
            new Invoice() { Id = 1, Customer = "a", Date = DateTime.Parse("1/1/2009") },
            new Invoice() { Id = 2, Customer = "a", Date = DateTime.Parse("1/2/2009") }, 
            new Invoice() { Id = 3, Customer = "a", Date = DateTime.Parse("1/2/2009") }, 
            new Invoice() { Id = 4, Customer = "b", Date = DateTime.Parse("1/1/2009") }, 
            new Invoice() { Id = 5, Customer = "b", Date = DateTime.Parse("1/1/2009") }, 
            new Invoice() { Id = 6, Customer = "b", Date = DateTime.Parse("1/2/2009") } 
        };
        StringBuilder sb = new StringBuilder();
        TextWriter tw = new StringWriter(sb);
        using (XmlWriter xmlWriter = new XmlTextWriter(tw) { Formatting = Formatting.Indented })
        {
            XElement t1 = new XElement("Root", BuildTree(invoices, i => i.Customer, i => i.Date, i => i.Id));
            XElement t2 = new XElement("Root", BuildTree(invoices, "Customer", "Date", "Id"));
            var xyz = t2.Elements("Customer").ElementAt(1).Descendants("Item").Count();
            t1.WriteTo(xmlWriter);
            t2.WriteTo(xmlWriter);
        }
        Console.WriteLine(sb.ToString());
        Console.ReadLine();
    }
    public static IEnumerable<XElement> BuildTree<T>(IEnumerable<T> collection, params Func<T, Object>[] groups)
    {
        if ((groups != null) && (groups.Length > 0))
        {
            return collection
                .GroupBy(groups[0])
                .Select(grp => new XElement(
                    "Group",
                    new XAttribute("Value", grp.Key),
                    BuildTree(grp, groups.Skip(1).ToArray())));
        }
        else
        {
            return collection.Select(i => new XElement("Item"));
        }
    }
    public static IEnumerable<XElement> BuildTree<T>(IEnumerable<T> collection, params String[] groups)
    {
        if ((groups != null) && (groups.Length > 0))
        {
            return collection
                .GroupBy(i => typeof(T).GetProperty(groups[0]).GetValue(i, null))
                .Select(grp => new XElement(
                    groups[0],
                    new XAttribute("Value", grp.Key),
                    BuildTree(grp, groups.Skip(1).ToArray())));
        }
        else
        {
            return collection.Select(i => new XElement("Item"));
        }
    }
