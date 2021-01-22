    static void InferSchema(string fileName)
    {
        XmlWriter writer = null;
        XmlSchemaInference infer = new XmlSchemaInference();
        XmlSchemaSet sc = new XmlSchemaSet();
    
        string outputXsd = fileName.Replace(".xml", ".xsd");
        sc = infer.InferSchema(new XmlTextReader(fileName));
    
        using (writer = XmlWriter.Create(new StreamWriter(outputXsd)))   
        {
            foreach(XmlSchema schema in sc.Schemas())
            {
                schema.Write(writer);
                Console.WriteLine(">> found schema - generated to {0}", 
                outputXsd);
            }
        }
    }
