    XElement TestElement = doc.Root.Elements().Where(element => element.Name.Equals("TestElement")).FirstOrDefault();
    if (TestElement != null)
    {
       XAttribute value = TestElement.Attributes().Where(attr => attr.Name.Equals("Count")).FirstOrDefault();
    }
