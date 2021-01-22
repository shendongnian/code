		public NameValueCollection StringToNameValueCollection(string KeyValueData, char KeyValueSeparator, char ItemSeparator)
		{
			NameValueCollection nvc = new NameValueCollection();
			// split string into array of key/value pairs
			string[] kvpairs = KeyValueData.Split(new char[]{ItemSeparator});
			// add each pair to the collection
			for (int i = 0; i < kvpairs.Length; i++)
			{
				if (!string.IsNullOrEmpty(kvpairs[i]))
				{
					if (kvpairs[i].Contains(KeyValueSeparator.ToString()))
					{
						// get the key
						string k = kvpairs[i].Remove(kvpairs[i].IndexOf(KeyValueSeparator.ToString())).Trim();
						// get the value
						string v = kvpairs[i].Remove(0, kvpairs[i].IndexOf(KeyValueSeparator) + 1).Trim();
						// add key/value if key is valid
						if (!string.IsNullOrEmpty(k))
						{
							nvc.Add(k, v);
						}
					}
					else
					{
						// no key/value separator in the pair, so add whole string as key and value
						nvc.Add(kvpairs[i].Trim(), kvpairs[i].Trim());
					}
				}
			}
			return nvc;
		}
