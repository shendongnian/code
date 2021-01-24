    if (algValue != null)
		{
			algValue.Clear();
		}
		else
		{
			throw new Exception("No TripleDES key was found to clear.");
		}
	}
	public void Encrypt(string Element)
	{
		// Find the element by name and create a new
		// XmlElement object.
		XmlElement inputElement = docValue.GetElementsByTagName(Element)[0] as XmlElement;
		// If the element was not found, throw an exception.
		if (inputElement == null)
		{
			throw new Exception("The element was not found.");
		}
		// Create a new EncryptedXml object.
		EncryptedXml exml = new EncryptedXml(docValue);
		// Encrypt the element using the symmetric key.
		byte[] rgbOutput = exml.EncryptData(inputElement, algValue, false);
