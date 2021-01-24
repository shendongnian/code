    public static List<LogData> GetLogDatas(string xml) {
        List<LogData> logDatas = new List<LogData>();
        string wasteFile = "wasteFile.xml";
        File.WriteAllText(wasteFile, xml);
        using (XmlReader reader = XmlReader.Create(wasteFile)) {
            // move to next "logData"
            while (reader.ReadToFollowing("logData")) {
                var logData = new LogData(reader.GetAttribute("id"));                    
                using (var logDataReader = reader.ReadSubtree()) {
                    // inside "logData" subtree, move to next "data"
                    while (logDataReader.ReadToFollowing("data")) {
                        // move to index
                        logDataReader.ReadToFollowing("index");
                        // read index
                        var index = int.Parse(logDataReader.ReadElementContentAsString());
                        // move to value
                        logDataReader.ReadToFollowing("value");
                        // read value
                        var value = double.Parse(logDataReader.ReadElementContentAsString(), CultureInfo.InvariantCulture);
                        logData.LogPoints.Add(new LogPoint(index, value));
                    }
                }
                logDatas.Add(logData);
            }
        }
        return logDatas;
    }
