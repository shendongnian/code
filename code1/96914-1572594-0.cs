    var xe = (from root in xdb.Descendants(NameSpace + "Field")
              where root.Attribute("Name").Value.Equals("Sim")
              select new N2NField
              {
                  Name    = (string)root.Attribute("Name"),
                  ID      = int.Parse((string)root.Element(NameSpace + "ID") ?? "0"),
                  Default = (string)root.Element(NameSpace + "Default"),
                  Head    = (string)root.Element(NameSpace + "Head"),
                  Tail    = (string)root.Element(NameSpace + "Tail"),
                  MinLength = int.Parse((string)root.Element(NameSpace + "MinLength") ?? "0"),
                  MaxLength = int.Parse((string)root.Element(NameSpace + "MaxLength") ?? "0")
              }).First();
