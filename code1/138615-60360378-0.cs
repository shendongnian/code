    public bool CompareXml()
    {
            var doc = @"
            <ContactPersons>
                <ContactPersonRole>General</ContactPersonRole>
                <Person>
                  <Name>Aravind Kumar Eriventy</Name>
                  <Email/>
                  <Mobile>9052534488</Mobile>
                </Person>
              </ContactPersons>";
            var doc1 = @"
            <ContactPersons>
                <ContactPersonRole>General</ContactPersonRole>
                <Person>
                  <Name>Aravind Kumar Eriventy</Name>
                  <Email></Email>
                  <Mobile>9052534488</Mobile>
                </Person>
              </ContactPersons>";
        return XmlDocCompare(XDocument.Parse(doc), XDocument.Parse(doc1));
    }
    private static bool XmlDocCompare(XDocument doc,XDocument doc1)
    {
        IntroduceClosingBracket(doc.Root);
        IntroduceClosingBracket(doc1.Root);
        return XNode.DeepEquals(doc1, doc);
    }
    private static void IntroduceClosingBracket(XElement element)
    {
        foreach (var descendant in element.DescendantsAndSelf())
        {
            if (descendant.IsEmpty)
            {
                descendant.SetValue(String.Empty);
            }
        }
    }
