        /// <summary>
        /// Makes the X path. Use a format like //configuration/appSettings/add[@key='name']/@value
        /// </summary>
        /// <param name="doc">The doc.</param>
        /// <param name="xpath">The xpath.</param>
        /// <returns></returns>
        public static XmlNode createNodeFromXPath(XmlDocument doc, string xpath)
        {
            // Create a new Regex object
            Regex r = new Regex(@"/+([\w]+)(\[@([\w]+)='([^']*)'\])?|/@([\w]+)");
            // Find matches
            Match m = r.Match(xpath);
            XmlNode currentNode = doc.FirstChild;
            StringBuilder currentPath = new StringBuilder();
            while (m.Success)
            {
                String currentXPath = m.Groups[0].Value;    // "/configuration" or "/appSettings" or "/add"
                String elementName = m.Groups[1].Value;     // "configuration" or "appSettings" or "add"
                String filterName = m.Groups[3].Value;      // "" or "key"
                String filterValue = m.Groups[4].Value;     // "" or "name"
                String attributeName = m.Groups[5].Value;   // "" or "value"
                StringBuilder builder = currentPath.Append(currentXPath);
                String relativePath = builder.ToString();
                XmlNode newNode = doc.SelectSingleNode(relativePath);
                if (newNode == null)
                {
                    if (!string.IsNullOrEmpty(attributeName))
                    {
                        ((XmlElement)currentNode).SetAttribute(attributeName, "");
                        newNode = doc.SelectSingleNode(relativePath);
                    }
                    else if (!string.IsNullOrEmpty(elementName))
                    {
                        XmlElement element = doc.CreateElement(elementName);
                        if (!string.IsNullOrEmpty(filterName))
                        {
                            element.SetAttribute(filterName, filterValue);
                        }
                        currentNode.AppendChild(element);
                        newNode = element;
                    }
                    else
                    {
                        throw new FormatException("The given xPath is not supported " + relativePath);
                    }
                }
                currentNode = newNode;
                m = m.NextMatch();
            }
            // Assure that the node is found or created
            if (doc.SelectSingleNode(xpath) == null)
            {
                throw new FormatException("The given xPath cannot be created " + xpath);
            }
            return currentNode;
        }
