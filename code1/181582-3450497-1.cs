		public static rsm GetRsmObject(string xmlString)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(rsm));
			rsm result = null;
			using (XmlTextReader reader = new XmlTextReader(new StringReader(xmlString)))
			{
				result = (rsm)serializer.Deserialize(reader);
			}
			return result;
		}
