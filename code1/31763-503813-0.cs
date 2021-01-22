        void CheckXml()
        {
            string _xmlFile = "this.xml";
            string _xsdFile = "schema.xsd"; 
            StringCollection _xmlErrors = new StringCollection();
            XmlReader reader = null;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventHandler);
            settings.ValidationType = ValidationType.Schema;
            settings.IgnoreComments = chkIgnoreComments.Checked;
            settings.IgnoreProcessingInstructions = chkIgnoreProcessingInstructions.Checked;
            settings.IgnoreWhitespace = chkIgnoreWhiteSpace.Checked;
            settings.Schemas.Add(null, XmlReader.Create(_xsdFile));
            reader = XmlReader.Create(_xmlFile, settings);
            while (reader.Read())
            {
            }
            reader.Close();
            Assert.AreEqual(_xmlErrors.Count,0);
        }    
        void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            _xmlErrors.Add("<" + args.Severity + "> " + args.Message);
        }
