    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.Load("...");
    using(StreamWriter writer = new StreamWriter("yourfile.txt"))
    foreach (XmlNode node in xmlDoc.SelectNodes("//Element/@*"))
    {
        writer.WriteLine(
            String.Format("textbox.Settings.Keywords.Add(\"{0}\")",
                node.Name));
    }
