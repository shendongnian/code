    class Program
        {
            static void Main(string[] args)
            {
                
            // to get embeded file name you have to add namespace of the application
            const string embeddedFilename = "ConsoleApplication3.FrostOrangeMappings.xml";
            // load file into stream
            var embeddedStream = GetEmbeddedFile(embeddedFilename);
            // process stream
            ProcessStreamToXmlMappingSource(embeddedStream);
            Console.ReadKey();
        }
        private static void ProcessStreamToXmlMappingSource(Stream stream)
        {
            const string newDatabaseName = "pavsDatabaseName";      
            var mappingFile = new XmlDocument();
            mappingFile.Load(stream);
            stream.Close();
            
            // populate collection of attribues
            XmlAttributeCollection collection = mappingFile.DocumentElement.Attributes;
            var attribute = collection["Name"];
            if(attribute==null)
            {
                throw new Exception("Failed to find Name attribute in xml definition");
            }
            // set new database name definition
            collection["Name"].Value = newDatabaseName;
            //display xml to  user
            var stringWriter = new StringWriter();
              using (var xmlTextWriter = XmlWriter.Create(stringWriter))
              {
                  mappingFile.WriteTo(xmlTextWriter);
                  xmlTextWriter.Flush();
                  stringWriter.GetStringBuilder();
              }
            Console.WriteLine(stringWriter.ToString());
         
        }
        /// <summary>
        /// Loads file into stream
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static Stream GetEmbeddedFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(fileName);
            if (stream == null)
                throw new Exception("Could not locate embedded resource '" + fileName + "' in assembly");
            return stream;
        }`
