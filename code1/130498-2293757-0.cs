            /// <summary>
        /// Does a simple convert to display an Xml document in HTML.
        /// </summary>
        /// <param name="xmlString"></param>
        private static string ConvertXmlToHtml(string xmlString)
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<HTML>");
            html.AppendLine("<HEAD><TITLE>Xml Document</TITLE></HEAD>");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            html.AppendLine(ConvertXmlElementToHTML(1, doc.DocumentElement));
            html.AppendLine("</HTML>");
            return html.ToString();
        }
        /// <summary>
        /// Converts an XML element (and all of its children) to HTML.
        /// This is a recursive method.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static string ConvertXmlElementToHTML(int level, XmlNode element)
        {
            int padding = level; // padding (cm == level).
            StringBuilder returnHTML = new StringBuilder();
            if (element is XmlElement)
            {
                // Formatting for symbols to simplify code below.
                string close_bracket = "<SPAN style=\"color: blue\">&gt;</SPAN>";
                string close_bracket_no_children = "<SPAN style=\"color: blue\"> /&gt;</SPAN>";
                string open_bracket = "<SPAN style=\"color: blue\">&lt;</SPAN>";
                string open_bracket_end_el = "<SPAN style=\"color: blue\">&lt;/</SPAN>";
                string el_name = "<SPAN style=\"color: brown\">" + element.Name + "</SPAN>";
                string quote = "<SPAN style=\"color: blue\">\"</SPAN>";
                string equals_sign = "<SPAN style=\"color: blue\">=</SPAN>";
                
                // Open Element.
                returnHTML.AppendLine("<DIV style=\"margin-left: " + padding + "cm\">" + open_bracket + el_name);
                // Print element attributes.
                foreach(XmlAttribute att in element.Attributes)
                {
                    returnHTML.AppendLine(" <SPAN style=\"color: brown\">" + att.Name + "</SPAN>" + equals_sign + quote + "<SPAN style=\"color: black; text-weight: bold\">" + att.Value + "</SPAN>" + quote);
                }
                // If no children, we end the element here with a '/ >'
                // otherwise, we close the element and start to write children '>'
                if (element.ChildNodes.Count == 0)
                {
                    returnHTML.AppendLine(close_bracket_no_children + "</DIV>");
                }
                else
                {
                    returnHTML.AppendLine(close_bracket + "</DIV>");
                }
                // Print Children. (Recursive call). Note location is IMPORTANT: we need child elements
                // to print after the element is opened and before the element is closed.
                foreach (XmlNode child in element.ChildNodes)
                {
                    returnHTML.AppendLine(ConvertXmlElementToHTML(level + 1, child));
                }
                // If we have printed child elements, we need to print a closing element tag.
                if (element.ChildNodes.Count > 0)
                {
                    returnHTML.AppendLine("<DIV style=\"margin-left: " + padding + "cm\">" + open_bracket_end_el + el_name + close_bracket + "</DIV>");
                }
            }
            // Return a string of HTML that will display elements at this level and below (child nodes).
            return returnHTML.ToString();
        }
