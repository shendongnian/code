    static public string serializeObject(ProductPriceLines objecteToSerialize)
		{
			System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(ProductPriceLines));
    
			System.IO.MemoryStream t = new System.IO.MemoryStream();
			mySerializer.Serialize(t, objecteToSerialize);
    
    
			UTF8Encoding utf = new UTF8Encoding();
			string strbytes = utf.GetString(t.ToArray());
    
    
			return strbytes;
		}
