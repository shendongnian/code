    public static string GetValue(string data, string classificationTypeValue, string referenceTypeValue)
    {
        // Serializing XML here
        Root root;
        System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Root));
        using (StringReader sr = new StringReader(data))
        {
            root = (Root)ser.Deserialize(sr);
        }
        if (root != null)
        {
            // First we'll get a components which have given classificationType E.g (Books,Movies)
            List<Component> componentWithReferenceType = root.Component.Where(x => x.Classification.ClassificationType == classificationTypeValue).ToList();
            // Now once we have componets with given classificationType all we have to do is grab it's first child and return it's referenceText
            return componentWithReferenceType.First(x => x.Reference.ReferenceType == referenceTypeValue).Reference.Text;
        }
        return string.Empty;
    }
