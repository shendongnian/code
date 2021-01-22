    public class Settings : IXmlSerializable
	{
		[XmlElement("IntervalInSeconds")]
		public TimeSpan Interval;
		public XmlSchema GetSchema()
		{
			return null;
        }
     	public void WriteXml(XmlWriter writer)
    	{
	    	writer.WriteElementString("IntervalInSeconds", ((int)Interval.TotalSeconds).ToString());
	    }
    	public void ReadXml(XmlReader reader)
		{
			string element = null;
			while (reader.Read())
			{
				if (reader.NodeType == XmlNodeType.Element)
					element = reader.Name;
				else if (reader.NodeType == XmlNodeType.Text)
		  		{
					if (element == "IntervalInSeconds")
						Interval = TimeSpan.FromSeconds(double.Parse(reader.Value.Replace(',', '.'), CultureInfo.InvariantCulture));
		  		}
		   }
		}
	}
