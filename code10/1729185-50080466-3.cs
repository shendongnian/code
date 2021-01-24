	public static List<LogData> GetLogDatasFromFile(string xmlFile)
	{
		List<LogData> logDatas = new List<LogData>();
	
		using (XmlReader reader = XmlReader.Create(xmlFile))
		{
			// move to next "logData"
			while (reader.ReadToFollowing("logData", ""))
			{
				var logData = new LogData(reader.GetAttribute("id"));
				using (var logDataReader = reader.ReadSubtree())
				{
					// inside "logData" subtree, move to next "data"
					while (logDataReader.ReadToFollowing("data", ""))
					{
						// move to index
						logDataReader.ReadToFollowing("index", "");
						// read index
						var index = int.Parse(logDataReader.ReadElementContentAsString());
						// move to value
						logDataReader.ReadToFollowingOrCurrent("value", "");
						// read value
						var value = XmlConvert.ToDouble(logDataReader.ReadElementContentAsString());
						logData.LogPoints.Add(new LogPoint(index, value));
					}
				}
				logDatas.Add(logData);
			}
		}
		return logDatas;
	}		
