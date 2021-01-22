    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ConformanceLevel = ConformanceLevel.Auto;
    settings.IgnoreWhitespace = true;
    settings.CloseInput = true;
    settings.IgnoreComments = true;
    settings.ValidationType = ValidationType.Schema;
    settings.Schemas.Add(null, "schema.xsd");
    settings.ValidationEventHandler += ValidationCallBack;
    using (XmlReader reader = XmlReader.Create("Sample.xml", settings))
    {
        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element &&
                reader.Name.Equals("A"))
            {
                using (
                    XmlReader subtree = reader.ReadSubtree())
                {
                    try {
                        processA(subtree);
                    }
                    catch (ImportException ex) { // log it at least }
                    catch (XmlException ex) {// log this too }
                    // I would not catch InvalidOperationException - too general
                }
            }
        }
    }
    private static void processA(XmlReader A)
    {
        using (XmlReader subtree = A.ReadSubtree())
        {
            processB(subtree);
        }
    }
    // All the lower level process node functions propagate the exception to caller.  
    private static void processB(XmlReader B)
    {
    }
