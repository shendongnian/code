		public override void SecureMessage(SoapEnvelope envelope, Security security)
		{
			//EncryptedData data = new EncryptedData(userToken);
			SignatureReference ssekSignature = new SignatureReference();
			MessageSignature signature = new MessageSignature(clientToken);
			// encrypt custom headers
			for (int index = 0; index < envelope.Header.ChildNodes.Count; index++)
			{
				XmlElement child =
				  envelope.Header.ChildNodes[index] as XmlElement;
				// find all FOO headers
				if (child != null && child.Name == "FOO")
				{
					string id = Guid.NewGuid().ToString();
					child.SetAttribute("Id", "http://docs.oasis-" +
						  "open.org/wss/2004/01/oasis-200401-" +
						  "wss-wssecurity-utility-1.0.xsd", id);
					signature.AddReference(new SignatureReference("#" + id));
				}
			}
			// Sign the SOAP message with the client's security token.
			security.Tokens.Add(clientToken);
			security.Elements.Add(signature);
		}
