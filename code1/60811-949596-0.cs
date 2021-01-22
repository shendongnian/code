            Content content;
            using(StringReader sr = new StringReader(xml))
            using(XmlReader xr = XmlReader.Create(sr)) {
                XmlSerializer ser = new XmlSerializer(typeof(Content));
                content = (Content)ser.Deserialize(xr);
            }
