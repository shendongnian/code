    var dashes = new String('-', 50);
    foreach (var element in xrefs) {
        var xd = XDocument.Parse("<root>" + element + "</root>");
        var len = xd.Descendants("xref").Count();
        var has3 = xd.Descendants("xref").Take(len - 2).Where(El => El.CompareNext() && El.NextElement().CompareNext()).Any();
        if (has3) {
            Console.WriteLine(dashes);
            Console.WriteLine(element);
            Console.WriteLine();
        }
    }
    public static class Ext {
        public static XElement NextElement(this XElement xe) => xe.ElementsAfterSelf().FirstOrDefault();
        public static bool CompareNext(this XElement xe) => Convert.ToInt16(xe.Attribute("rid").Value.Replace("ref", "")) + 1 == Convert.ToInt16(xe.NextElement().Attribute("rid").Value.Replace("ref", ""));
    }
