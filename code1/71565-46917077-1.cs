			if (File.Exists(Path))
			{
				using (XmlTextReader reader = new XmlTextReader(Path))
				{
					// XmlSerializer x  = new XmlSerializer(typeof(T));
					var x = XmlSerializerHelper.GetSerializer(typeof(T));
					try
					{
						options = (OptionsBase<T>)x.Deserialize(reader);
					}
					catch (Exception ex)
					{
						Log.Log.Instance.AddEntry(LogType.LogException, "Unable to open Options file: " + Path, ex);
					}
				}
			}
