    public void SaveLines(ref XmlTextWriter writer, List<Line> myLines)
    {
        foreach(Line line in MyLines)
        {
           writer.WriteStartElement("line");
           writer.Add(new XElement("pattern", line.pattern));
           writer.Add(new XElement("description", line.description));
           writert.Add(new XElement("CallForwardAll", 
                       new XElement("forwardToVoiceMail", line.forwardToVoiceMail));
  ...
        }
