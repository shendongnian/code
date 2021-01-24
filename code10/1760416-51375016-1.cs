    public static List Deserialize(string xml)
        {
            var serializer = new XmlSerializer(typeof(List), new XmlRootAttribute("list"));
            List list = null;
            var xdoc = XDocument.Parse(xml);
            list = (List)serializer.Deserialize(xdoc.CreateReader());
            return list;
        }
