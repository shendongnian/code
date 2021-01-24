    Arguments = xmlNode.Descendants().FirstOrDefault();
                if(Arguments != null)
            {
                HtmlNode arguments = doc.CreateElement(XamlNodeType.GetXamlElementName() + ".Arguments");
                
                arguments.AppendChild(XmlFragment);
                el.AppendChild(arguments);
            }
