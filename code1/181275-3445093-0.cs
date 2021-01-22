    XDocument xdoc = XDocument.Load(new StringReader(my_WoW_XML_String));
    
    var statsObject = new
    {
        StrengthInfo = new
        {
            Attack = int.Parse(xdoc.Element("strength").Element("attack").Value),
            Base = int.Parse(xdoc.Element("strength").Element("base").Value),
            Block = int.Parse(xdoc.Element("strength").Element("block").Value),
            Effective = int.Parse(xdoc.Element("strength").Element("effective").Value),
        },
    
        AgilityInfo = new
        {
            Armor = int.Parse(xdoc.Element("agility").Element("armor").Value),
            Attack = int.Parse(xdoc.Element("agility").Element("attack").Value),
            Base = int.Parse(xdoc.Element("agility").Element("base").Value),
            CritHitPercent = int.Parse(xdoc.Element("agility").Element("critHitPercent").Value),
            Effective = int.Parse(xdoc.Element("agility").Element("effective").Value),
        }
    
        // Do the same with <spirit> and <armor> elements, etc.
    
    }; // end anon object.
