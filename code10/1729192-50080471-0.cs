    public static List<LogData> GetLogDatasFromFile(string xmlFile) {
        List<LogData> logDatas = new List<LogData>();
        using (XmlReader reader = XmlReader.Create(xmlFile)) {
            LogData currentData = null;
            while (reader.Read()) {
                if (reader.IsStartElement("logData")) {
                    // we are positioned on start of logData
                    if (currentData != null)
                        logDatas.Add(currentData);
                    currentData = new LogData(reader.GetAttribute("id"));
                }
                else if (reader.IsStartElement("data")) {
                    // we are on start of "data"
                    // we always have "currentData" at this point                        
                    Debug.Assert(currentData != null);
                    reader.ReadToFollowing("index");
                    var index = int.Parse(reader.ReadElementContentAsString());
                    // check if we are not already on "value"
                    if (!reader.IsStartElement("value"))
                        reader.ReadToFollowing("value");
                    var value = double.Parse(reader.ReadElementContentAsString(), CultureInfo.InvariantCulture);
                    currentData.LogPoints.Add(new LogPoint(index, value));
                }
            }
            if (currentData != null)
                logDatas.Add(currentData);
        }
        return logDatas;
    }
