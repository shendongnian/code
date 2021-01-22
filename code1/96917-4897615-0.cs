    var xe = (from root in xdb.Descendants(NameSpace + "Field")
              where root.Attribute("Name").Value.Equals(Name)
              select new N2NField
              {
                  Name = root.Attribute("Name").Value,
                  ID = int.Parse(root.Element(NameSpace + "ID").Value),
                  Default = root.Elements(NameSpace + "Default").Any ? root.Element(NameSpace + "Default").Value : null,
                  Head = root.Elements(NameSpace + "Head").Any ? root.Element(NameSpace + "Head").Value : null,
                  
    
              }).First();
