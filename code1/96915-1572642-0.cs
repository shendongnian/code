    XElement xdb = XElement.Load(XMLPath);
                XNamespace NameSpace = xdb.Name.Namespace;
    
                var xe = (from root in xdb.Descendants(NameSpace + "Field")
                               where root.Attribute("Name").Value.Equals(Name)                                       
                               select new N2NField
                                           {
                                               Name = root.Attribute("Name").Value,
                                               ID = int.Parse(root.Element(NameSpace+"ID").Value),
                                               Default = root.Descendants(NameSpace + "Default").Any() ? root.Element(NameSpace + "Default").Value : null,
                                               Head = root.Descendants(NameSpace+"Head").Any() ? root.Element(NameSpace + "Head").Value : null,
                                               Tail = root.Descendants(NameSpace+"Tail").Any() ? root.Element(NameSpace + "Tail").Value : null,
                                               MinLength = root.Descendants(NameSpace+"MinLength").Any()  ? int.Parse(root.Element(NameSpace + "MinLength").Value) : -1,
                                               MaxLength = root.Descendants(NameSpace+"MaxLength").Any() ? int.Parse(root.Element(NameSpace + "MaxLength").Value) : -1                                           
    
                                           }
                                           ).First();
