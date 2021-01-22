    Products products = new Products();
    products.Add(new Product());
    XmlSerializer serializer = new XmlSerializer(typeof(Products));
    using (StringWriter sw = new StringWriter())
    {
        serializer.Serialize(sw, products);
        string serializedString = sw.ToString();
    }
