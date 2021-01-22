		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			// Simple string value
			this.Name = reader.GetAttribute("Name");
			// Object without IXmlSerializable implementation here:
			reader.ReadStartElement();
			if (reader.Name == "NonCustomObject")
			{
				reader.ReadStartElement();
				this.NonCustomObject = new XmlSerializer(NonCustomObjectType).Deserialize(reader);
				reader.ReadEndElement();
			}
			// Object with IXmlSerializable implementation here:
			reader.ReadStartElement();
			if (reader.Name == "CustomObject")
			{	
				(this.CustomObject as IXmlSerializable).ReadXml(reader);
				reader.ReadEndElement();
			}
		}
