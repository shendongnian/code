    static void Main(string[] args)
    {
        string invalidXml = "your invalid XML";
        int closeTagPos = -1;
        int openTagPos = -1;
        string openTagId = "";
        string closeTagId = "";
        while (true)
        {
            //get indexes of opening tag and close tag, break, if none is found
            if((openTagPos = invalidXml.IndexOf("<sec id=\"sec", openTagPos + 1)) == -1)
                break;
            if((closeTagPos = invalidXml.IndexOf("<sec id=\"sec", openTagPos + 1)) == -1)
                break;
            //get the IDs of tags
            openTagId = invalidXml.Substring(
                openTagPos + 12,
                invalidXml.IndexOf('"', openTagPos + 12) - openTagPos - 12
            );
            closeTagId = invalidXml.Substring(
                closeTagPos + 12,
                invalidXml.IndexOf('"', closeTagPos + 12) - closeTagPos - 12
            );
            //count how many tags were already closed
            int howManyClosingTagsAlready = 0;
            int lastPos = invalidXml.IndexOf("</sec>", openTagPos);
            while (lastPos > -1 && lastPos < closeTagPos)
            {
                howManyClosingTagsAlready++;
                lastPos = invalidXml.IndexOf("</sec>", lastPos + 1);
            }
            int howManyTagsToInsert = HowManyClosingTags(openTagId, closeTagId) - howManyClosingTagsAlready;
            for (int i = 0; i < howManyTagsToInsert; i++)
            {
                //insert closing tags
                invalidXml = invalidXml.Insert(closeTagPos, "</sec>");
            }
        }
        //insert closing tags for last <sec> element
        openTagId = invalidXml.Substring(
            openTagPos + 12,
            invalidXml.IndexOf('"', openTagPos + 12) - openTagPos - 12
        );
        for (int i = 0; i < openTagId.Count(ch => ch == '.') - 1; i++)
        {
            //insert closing tags
            invalidXml = invalidXml.Insert(invalidXml.IndexOf("</body>"), "</sec>");
        }
        //this is also validation of XML, it would throw excepion in case of any errors in XML
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(invalidXml);
    }
