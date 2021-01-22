      /// <summary>
      /// Method to load a Resources.resx file (if it exists) as an XML Document object.
      /// </summary>
      private static XmlDocument LoadResourcesResx(string projectPath)
      {
         string fileName = projectPath + @"Properties\Resources.resx";
         if (!File.Exists(fileName))
            return null;
         XmlDocument xdResx = new XmlDocument();
         xdResx.Load(fileName);
         return xdResx;
      }
...
      /// <summary>
      /// Method to fix the names of any resources that contain '-' instead of '_'.
      /// </summary>
      private static void FixResourceNames(XmlDocument xdResx, ref bool resxModified)
      {
         // Loop for all of the <data> elements that have name= attributes (node = "name" attr.)
         XmlNodeList xnlDataElements = xdResx.SelectNodes("/root/data/@name");
         if (xnlDataElements != null)
         {
            foreach (XmlNode xmlNode in xnlDataElements)
            {
               // Modify the name= attribute if necessary
               string oldDataName = xmlNode.Value;
               string newDataName = oldDataName.Replace('-', '_');
               if (oldDataName != newDataName)
               {
                  xmlNode.Value = newDataName;
                  resxModified = true;
               }
            }
         }
      }
