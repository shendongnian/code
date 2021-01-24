    using (XmlTextWriter writer = new XmlTextWriter("DataW.xml", System.Text.Encoding.UTF8))
    {
        writer.Formatting = Formatting.Indented;
        writer.WriteStartDocument();
        writer.WriteComment("This is a comment");
        writer.WriteStartElement("Weekly Review");
        writer.WriteStartElement("DateTime");
        writer.WriteStartAttribute("09/04/2018 05:00");
        writer.WriteElementString("Activity", "At Theodor");
        writer.WriteElementString("Social", "Not Theodor,Theodor");
    }
