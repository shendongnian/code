            I have an Xml File books.xml
            <ParameterDBConfig>
            <ID            Definition="1" />
            </ParameterDBConfig>
            XmlDocument doc = new XmlDocument();
            doc.Load("D:/siva/books.xml");
            XmlNodeList elemList = doc.GetElementsByTagName("ID");     
            for (int i = 0; i < elemList.Count; i++)     
            {
                string attrVal = elemList[i].Attributes["Definition"].Value;
                
            }
            Now,attrval have the value of ID.
