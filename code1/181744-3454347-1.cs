    public int SomeSortOfUniqueID
    {
    	get
    	{
    		//guess what this property has to do!
    	}
    }
    public void WriteXml(XmlWriter writer)
    {
    	WriteXml(writer, new HashSet<BindingNode>());
    }
    private void WriteXml(XmlWriter writer, HashSet<BindingNode> alreadyWritten)
    {
    	if(alreadyWritten.Add(this))
    	{
    		writer.WriteStartElement("BindingNode");
    		writer.WriteAttributeString("uniqueID", SomeSortOfUniqueID.ToString());
    		//More stuff here.
    		foreach(BindingNode contained in this)
    			contained.WriteXml(writer, alreadyWritten);
    		writer.WriteEndElement();
    	}
    	else
    	{
    		//we need to reference a node already mentioned in the document.
    		writer.WriteStartElement("BindingNode");
    		writer.WriteAttributeString("refID", SomeSortOfUniqueID.ToString());
    		writer.WriteEndElement();
    	}
    }
