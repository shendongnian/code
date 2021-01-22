            XDocument doc = null;
            using (StreamReader streamReader =
                new StreamReader(@"myXml.csproj"))
            {
                doc = XDocument.Load(streamReader, LoadOptions.None);
            }
            XNamespace rootNamespace = doc.Root.Name.NamespaceName;
            // A search which finds the ItemGroup which has Reference 
            // elements and returns the ItemGroup XElement.
            XElement element = doc.Descendants().Where(p => p.Name.LocalName == "ItemGroup"
                && p.Descendants().First<XElement>().Name.LocalName == "Reference").First<XElement>();
            // Create a completly new element with sub elements.
            XElement referenceElement = new XElement(rootNamespace + "Reference",
                new XElement(rootNamespace + "SpecificVersion", bool.FalseString),
                new XElement(rootNamespace + "HintPath", "THIS IS A HINT PATH"));
 
           // Add the new element to the main doc, to the end of the Reference elements.
            element.Add(referenceElement);
            
            // Add an attribute after the fact for effect.
            referenceElement.SetAttributeValue("Include", "THIS IS AN INCLUDE");
            rtb.Text = doc.ToString(SaveOptions.None);
