    //Sets the text for a Word XML <w:t> node
    //If the text is multi-line, it replaces the single <w:t> node for multiple nodes
    //Resulting in multiple Word XML lines
    private static void SetWordXmlNodeText(XmlDocument xmlDocument, XmlNode node, string newText)
    {
        //Is the text a single line or multiple lines?>
        if (newText.Contains(System.Environment.NewLine))
        {
            //The new text is a multi-line string, split it to individual lines
            var lines = newText.Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //And add XML nodes for each line so that Word XML will accept the new lines
            var xmlBuilder = new StringBuilder();
            for (int count = 0; count < lines.Length; count++)
            {
                //Ensure the "w" prefix is set correctly, otherwise docFrag.InnerXml will fail with exception
                xmlBuilder.Append("<w:t xmlns:w=\"http://schemas.microsoft.com/office/word/2003/wordml\">");
                xmlBuilder.Append(lines[count]);
                xmlBuilder.Append("</w:t>");
                //Not the last line? add line break
                if (count != lines.Length - 1)
                {
                    xmlBuilder.Append("<w:br xmlns:w=\"http://schemas.microsoft.com/office/word/2003/wordml\" />");
                }
            }
            //Create the XML fragment with the new multiline structure
            var docFrag = xmlDocument.CreateDocumentFragment();
            docFrag.InnerXml = xmlBuilder.ToString();
            node.ParentNode.AppendChild(docFrag);
            //Remove the single line child node that was originally holding the single line text, only required if there was a node there to start with
            node.ParentNode.RemoveChild(node);
        }
        else
        {
            //Text is not multi-line, let the existing node have the text
            node.InnerText = newText;
        }
    }
