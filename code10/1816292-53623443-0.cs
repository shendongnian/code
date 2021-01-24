	public void ReadXml(XmlReader reader)
	{
		reader.MoveToContent();
		
		this.Name = reader.LocalName; // Do not include the prefix (if present) in the Name.
		
		if (reader.HasAttributes)
		{
			var id = reader.GetAttribute("id");
			if (id != null)
				// Since id is missing from some elements you might want to make it nullable
				this.Id = XmlConvert.ToInt32(id);
			var order = reader.GetAttribute("itemOrder");
			if (order != null)
				// Since itemOrder is missing from some elements you might want to make it nullable
				this.Order = XmlConvert.ToInt32(order);
			string sequence = reader.GetAttribute("seq");
			//There is no Sequence property?
			//this.Sequence = Convert.ToInt32(sequence);
		}
		// Read element value.
		// This method reads the start tag, the contents of the element, and moves the reader past the end element tag.
		// thus there is no need for an additional Read()
		this.Value = reader.ReadElementContentAsString();
	}
