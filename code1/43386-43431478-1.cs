            // Prepare to add resource nodes to client-basic's Resource.resx file
            XmlNode rootNodeBasic = xdResx.SelectSingleNode("/root");
...
      /// <summary>
      /// Sub-method of above method (not included here) to copy a new icon usage from one of the client-maxi projects 
      /// to the client-basic project.
      /// </summary>
      private static bool CopyIconToClientBasic(string projectPath, XmlDocument xdResxBasic, 
                                                XmlNode rootNodeBasic, XmlNode xmlNodeMaxi)
      {
         // Check if this is an icon-based resource, and get the resource name if so
         string oldDataName = GetAndCheckResourceName(xmlNodeMaxi);
         if (oldDataName == null)
            return false;
         // Determine if there is a 16x16, 20x20, 24x24, 32x32 or 48x48 version of this icon 
         //  available, picking the lowest size to reduce client-basic assembly increase for a 
         //  resource which will probably never be used
         string oldFileName = xmlNodeMaxi.FirstChild.InnerText.Split(';')[0];
         string minSize = FindMinimumIconSize(projectPath, oldFileName);  // Not included here
         if (minSize == null)
            return false;  // Something wrong, can't find icon file
         // Test if client-basic's resources includes a version of this icon for smallest size
         string newDataName = oldDataName.Remove(oldDataName.Length - 5) + minSize;
         if (xdResxBasic.SelectSingleNode("/root/data[@name='" + newDataName + "']") != null)
            return false;  // Already in client-basic
         // Add the smallest available size version of this icon to the client-basic project
         string oldSize = oldDataName.Substring(oldDataName.Length - 5);  // "16x16", "20x20"
         XmlNode newNodeBasic = xdResxBasic.ImportNode(xmlNodeMaxi, true);
         if (newNodeBasic.Attributes != null)
            newNodeBasic.Attributes["name"].Value = newDataName;  // Maybe force smaller size
         newNodeBasic.FirstChild.InnerText =
                                  newNodeBasic.FirstChild.InnerText.Replace(oldSize, minSize);
         rootNodeBasic.AppendChild(newNodeBasic);
         return true;
      }
