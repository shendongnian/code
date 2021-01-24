    static XElement stripNS(XElement root)
    {
        return new XElement(
            root.Name.LocalName,
            root.HasElements ?
                root.Elements().Select(el => stripNS(el)) :
                (object)root.Value
        );
    }
    
    static void Main(string[] args)
    {
    
        string mathMLResult = @"<math xmlns='bla'>
                        <SnippetCode>
                            testcode1
                        </SnippetCode>
                    </math>";
    
        XDocument xmld = XDocument.Parse(mathMLResult);
        XNamespace bla = "bla";
        var mathNode = xmld.Element(bla + "math");
        mathNode = stripNS(mathNode);
        List<XNode> childNodes = mathNode.Nodes().ToList();
    
        XElement mrow = new XElement("mrow");
        mrow.Add(childNodes);
        mathNode.RemoveNodes();
    
        XElement mstyle = new XElement("mstyle");
        XElement semantics = new XElement("semantics");
        XElement annotation = new XElement("annotation",
        new XAttribute("encoding", "&quot;application/x-tex&quot;"));
        semantics.Add(mrow);
        semantics.Add(annotation);
        mstyle.Add(semantics);
        mathNode.Add(mstyle);
    
        var s = mathNode.ToString();
        Console.WriteLine(s);
    }
