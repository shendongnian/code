    using (XmlTextWriter writer = new XmlTextWriter("DataW.xml", System.Text.Encoding.UTF8))
    {
        writer.Formatting = Formatting.Indented;
        writer.WriteStartDocument();
        writer.WriteComment("This is a comment");
        writer.WriteStartElement("Weekly Review"); //NB: A space in an element name!
        writer.WriteStartElement("DateTime");
        writer.WriteStartAttribute("09/04/2018 05:00"); //NB: a value given as an attribute name (consider: WriteAttributeString)!
        writer.WriteElementString("Activity", "At Theodor");
        writer.WriteElementString("Social", "Not Theodor,Theodor");
    }
