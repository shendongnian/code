    private static string sectionName = "departments";
    public static Departments Deserialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Departments), new XmlRootAttribute(sectionName));
            Departments departments = null;
            var xdoc = XDocument.Parse(xml);
            departments = (Departments)serializer.Deserialize(xdoc.CreateReader());
            //var serializer = new XmlSerializer(typeof(Departments));
            //using (var reader = new StringReader(xml))
            //{
            //    departments = (Departments)(serializer.Deserialize(reader));
            //}
            return departments;
        }
