    XmlDeserializationEvents events = new XmlDeserializationEvents();
	events.OnUnknownElement = delegate(object sender, XmlElementEventArgs args)
	{
		if (args.Element.Name == "office")
		{
			var data = (Data) args.ObjectBeingDeserialized;
			var item = new Office(args.Element);
			data.ExtensionObjects.Add(item);
		}
	};
	var response = (Response) serializer.Deserialize(xmlReader, events);
