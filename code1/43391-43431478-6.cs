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
          
       // ---------------------------------------------------------------------------
    
    
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
          
       // ---------------------------------------------------------------------------
    
                // Prepare to add resource nodes to client-basic's Resources.resx file
                XmlNode rootNodeBasic = xdResx.SelectSingleNode("/root");
       // ---------------------------------------------------------------------------
    
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
    
       // ---------------------------------------------------------------------------
    
          /// <summary>
          /// Method to filter out non-icon resources and return the resource name for the icon-based 
          /// resource in the Resources.resx object.
          /// </summary>
          /// <returns>name of resource, i.e., name= value, or null if not icon resource</returns>
          private static string GetAndCheckResourceName(XmlNode xmlNode)
          {
             // Ignore resources that aren't PNG-based icon files with a standard size. This 
             //  includes ignoring ICO-based resources.
             if (!xmlNode.FirstChild.InnerText.Contains(";System.Drawing.Bitmap,"))
                return null;
             if (xmlNode.Attributes == null)
                return null;
    
             string dataName = xmlNode.Attributes["name"].Value;
    
             if (dataName.EndsWith("_16x16", StringComparison.Ordinal) ||
                 dataName.EndsWith("_20x20", StringComparison.Ordinal) ||
                 dataName.EndsWith("_24x24", StringComparison.Ordinal) ||
                 dataName.EndsWith("_32x32", StringComparison.Ordinal) ||
                 dataName.EndsWith("_48x48", StringComparison.Ordinal))
                return dataName;
    
             return null;
          }
    
       // ---------------------------------------------------------------------------
    
             // It's too messy to create a new node from scratch when not using the ResXResourceWriter 
             //  facility, so we cheat and clone an existing icon entry, the one for Cancel buttons
    
             // Get the Cancel icon name and filename
             BuiltInIcon cancelIcon = BuiltInIconNames.FindIconByName(BuiltInIconNames.CCancel);
             string cancelIconResourceName = cancelIcon.ResourceName + "_16x16";
    
             // Find it in the Resources.resx file - it should be there
             XmlNode cancelIconNode = 
                     xdResxBasic.SelectSingleNode("/root/data[@name='" + cancelIconResourceName + "']");
             if (cancelIconNode == null)
             {
                PreprocessorMain.DisplayError(0x27b699fu, "Icon " + cancelIconResourceName + 
                                                          " not found in Resources.resx file.");
                return false;
             }
    
             // Make a clone of this node in the Resources.resx file
             XmlNode newNode = cancelIconNode.Clone();
             if (newNode.Attributes == null) // Not possible?
             {
                PreprocessorMain.DisplayError(0x27b8038u, "Node for icon " + cancelIconResourceName + 
                                                          " not as expected in Resources.resx file.");
                return false;
             }
    
             // Modify the cloned XML node to represent the desired icon file/resource and add it to the 
             //  Resources.resx file
             newNode.Attributes["name"].Value = iconResourceName;
             newNode.InnerText = 
                      newNode.InnerText.Replace(cancelIcon.FileNameNoSize + "-16x16.png", iconFileName);
             rootNodeBasic.AppendChild(newNode);
             resxModified = true;
