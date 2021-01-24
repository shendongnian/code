    XmlDocument readDoc = new XmlDocument();
    readDoc.Load(@"XML.xml");
    var Node = readDoc.SelectNodes("Participants/Participant/Team");
    Dictionary<string, int> teamList = new Dictionary<string, int>();
    foreach (XmlNode n in Node)
    {
        if (teamList.ContainsKey(n.InnerText))
            teamList[n.InnerText]++;
        else
            teamList.Add(n.InnerText, 1);
    }
