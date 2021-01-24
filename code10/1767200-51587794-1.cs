    [HttpGet]
            public IHttpActionResult Test()
            {
                var doc = new XmlDocument();
                XmlElement tournament = (XmlElement)doc.AppendChild(doc.CreateElement("Tournament"));
                XmlElement match = (XmlElement)tournament.AppendChild(doc.CreateElement("Match"));
                match.SetAttribute("ID", "SomeMatch");
                return Ok(doc.DocumentElement);                 
            }
