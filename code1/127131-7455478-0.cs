		void IXmlSerializable.WriteXml(XmlWriter writer)
		{
			// Simple string value:
			writer.WriteAttributeString("Name", this.Name);
			// Object without IXmlSerializable implementation:
			writer.WriteStartElement("NonCustomObject");
			new XmlSerializer(NonCustomObjectType).Serialize(writer, this.NonCustomObject);
			writer.WriteEndElement();
			// Object with IXmlSerializable implementation:
			writer.WriteStartElement("CustomObject");
			(this.CustomObject as IXmlSerializable).WriteXml(writer);
			writer.WriteEndElement();
		}
