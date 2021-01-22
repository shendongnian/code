       public static string TotalMemberCount()
        {
            int totalCount = 0;
            using (XmlTextReader reader = new XmlTextReader(HttpContext.Current.Server.MapPath("~/Newsletter/NewsLetter.xml")))
            {
                while (reader.Read())
                {
                    if (reader.NodeType != XmlNodeType.XmlDeclaration && reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.MoveToFirstAttribute())
                        {
                            if (reader.Value == "True")
                                //gotcha, I don't want this,this is root element
                                continue;
                        }
                        totalCount++;
                    }
                }
                return totalCount.ToString();
            }
    
        }
