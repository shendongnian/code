    public class CXmlValidator
    {
        private int nErrors = 0;
        private string strErrorMsg = string.Empty;
        public string Errors { get { return strErrorMsg; } }
        public void ValidationHandler(object sender, ValidationEventArgs args)
        {
            nErrors++;
            strErrorMsg = strErrorMsg + args.Message + "\r\n";
        }
    
        public bool IsValidXml(string strXml/*xml in text*/, string strXsdLocation /*Xsd location*/)
        {
            bool bStatus = false;
            try
            {
                // Declare local objects
                XmlTextReader xtrReader = new XmlTextReader(strXsdLocation);
                XmlSchemaCollection xcSchemaCollection = new XmlSchemaCollection();
                xcSchemaCollection.Add(null/*add your namespace string*/, xtrReader);//Add multiple schemas if you want.
    
                XmlValidatingReader vrValidator = new XmlValidatingReader(strXml, XmlNodeType.Document, null);
                vrValidator.Schemas.Add(xcSchemaCollection);
    
                // Add validation event handler
                vrValidator.ValidationType = ValidationType.Schema;
                vrValidator.ValidationEventHandler += new ValidationEventHandler(ValidationHandler);
    
                //Actual validation, read conforming the schema.
                while (vrValidator.Read()) ;
    
                vrValidator.Close();//Cleanup
    
                //Exception if error.
                if (nErrors > 0) { throw new Exception(strErrorMsg); }
                else { bStatus = true; }//Success
            }
            catch (Exception error) { bStatus = false; }
    
            return bStatus;
        }
    }
