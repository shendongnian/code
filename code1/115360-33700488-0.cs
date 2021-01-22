	public static bool setConfigValue(Configuration config, string key, string val, out string errorMsg) {
		try {
			errorMsg = null;
			string filename = config.FilePath;
			
			//Load the config file as an XDocument
			XDocument document = XDocument.Load(filename, LoadOptions.PreserveWhitespace);
			if(document.Root == null) {
				errorMsg = "Document was null for XDocument load.";
				return false;
			}
			XElement appSettings = document.Root.Element("appSettings");
			if(appSettings == null) {
				appSettings = new XElement("appSettings");
				document.Root.Add(appSettings);
			}
			XElement appSetting = appSettings.Elements("add").FirstOrDefault(x => x.Attribute("key").Value == key);
			if (appSetting == null) {
				//Create the new appSetting
				appSettings.Add(new XElement("add", new XAttribute("key", key), new XAttribute("value", val)));
			}
			else {
				//Update the current appSetting
				appSetting.Attribute("value").Value = val;
			}
			//Format the appSetting section
			XNode lastElement = null;
			foreach(var elm in appSettings.DescendantNodes()) {
				if(elm.NodeType == System.Xml.XmlNodeType.Text) {
					if(lastElement?.NodeType == System.Xml.XmlNodeType.Element && elm.NextNode?.NodeType == System.Xml.XmlNodeType.Comment) {
						//Any time the last node was an element and the next is a comment add two new lines.
						((XText)elm).Value = "\n\n\t\t";
					}
					else {
						((XText)elm).Value = "\n\t\t";
					}
				}
				lastElement = elm;
			}
			//Make sure the end tag for appSettings is on a new line.
			var lastNode = appSettings.DescendantNodes().Last();
			if (lastNode.NodeType == System.Xml.XmlNodeType.Text) {
				((XText)lastNode).Value = "\n\t";
			}
			else {
				appSettings.Add(new XText("\n\t"));
			}
			//Save the changes to the config file.
			document.Save(filename, SaveOptions.DisableFormatting);
			return true;
		}
		catch (Exception ex) {
			errorMsg = "There was an exception while trying to update the config value for '" + key + "' with value '" + val + "' : " + ex.ToString();
			return false;
		}
	}
