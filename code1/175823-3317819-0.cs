    public IEnumerable<MyXmlData> QueryFile(String xmlFile)
    {
        using (var reader = XmlReader.Create(xmlFile))
        {
            // These are the variables you want to read for each 'object' in the
            // xml file.
            var prop1 = String.Empty;
            var prop2 = 0;
            var prop3 = DateTime.Today;
    
            while (reader.Read())
            {
                // Here you'll have to read an xml node at a time.
                // As you read, assign appropriate values to the variables
                // declared above.
                if (/* Have we finished reading an item? */)
                {
                    // Once you've completed reading xml representing a single
                    // MyXmlData object, return it using yield return.
                    yield return new MyXmlData(prop1, prop2, prop3);
                }
            }
        }
    }
