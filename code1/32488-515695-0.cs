        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            XmlDocument doc = new XmlDocument();
            XmlElement root = (XmlElement) doc.AppendChild(doc.CreateElement("Contents"));
            root.AppendChild(doc.CreateElement("From")).InnerText = "some text";
            root.AppendChild(doc.CreateElement("To")).InnerText = "some more text";
            root.AppendChild(doc.CreateElement("Subject")).InnerText = "this & that";
            root.AppendChild(doc.CreateElement("Message")).InnerText = "a < b > c";
            doc.Save(context.Response.Output);
        }
