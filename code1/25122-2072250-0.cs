	using (MemoryStream stream = new MemoryStream()) {
		using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8)) {
			writer.WriteStartDocument(); //<?xml version="1.0" encoding="utf-8"?>
			writer.WriteRaw("\r\n"); //endline
			writer.Flush(); //Write immediately the stream
			dTable.WriteXml(stream);
		}
	}
