    static void SafeMain(string[] args)
    {
        // convert bad xml into good xml (preserving encoding)
        // html agility pack will fix unclosed node automatically
        // but it will close them at document's end, as it cannot be smart enough to fix "sec" sections depending on the attribute value
        var doc = new HtmlDocument(); // from HtmlAgilityPack namespace
        doc.Load("MyPseudoXml.txt");
        var xml = new XmlDocument();
        using (var ms = new MemoryStream())
        {
            using (var writer = new StreamWriter(ms, doc.StreamEncoding))
            {
                doc.Save(writer);
                ms.Position = 0;
                using (var reader = new StreamReader(ms, doc.StreamEncoding))
                {
                    xml.Load(reader);
                }
            }
        }
        var body = xml["body"];
        // fix parenting
        // we need to process all nodes before doing final replacement
        var replaces = new List<XmlNode>();
        foreach (var node in body.SelectNodes("//sec").OfType<XmlElement>().Where(e => e.GetAttribute("id")?.IndexOf('.') < 0))
        {
            // since parenting is wrong, some nodes can again contain "root" sec nodes, so we want to remove them from this node
            // but keep them in the whole document, so we clone nodes
            var clone = node.CloneNode(true);
            foreach (var child in clone.SelectNodes("//sec").OfType<XmlElement>().Where(e => e.GetAttribute("id")?.IndexOf('.') < 0))
            {
                child.ParentNode.RemoveChild(child);
            }
            replaces.Add(clone);
        }
        // now clear body and insert back all processed nodes
        body.RemoveAll();
        foreach (var replace in replaces)
        {
            body.AppendChild(replace);
        }
        // save the valid xml file
        xml.Save("MyXml.xml");
    }
