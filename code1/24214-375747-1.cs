    using System.Xml; 
    using System.Xml.Schema; 
    using System.IO; 
    
    static class Program
    {     
        private static bool _Valid = true; //Until we find otherwise 
        
        private static void Invalidated() 
        { 
            _Valid = false; 
        } 
        
        private static bool Validated(XmlTextReader Xml, XmlTextReader Xsd) 
        { 
            
            var MySchema = XmlSchema.Read(Xsd, new ValidationEventHandler(Invalidated)); 
            
            var MySettings = new XmlReaderSettings(); 
            { 
                MySettings.IgnoreComments = true; 
                MySettings.IgnoreProcessingInstructions = true; 
                MySettings.IgnoreWhitespace = true; 
            } 
            
            var MyXml = XmlReader.Create(Xml, MySettings); 
            while (MyXml.Read) { 
              //Parsing...
            } 
            return _Valid; 
        } 
        
        public static void Main() 
        { 
            var XsdPath = "C:\\Path\\To\\MySchemaDocument.xsd"; 
            var XmlPath = "C:\\Path\\To\\MyXmlDocument.xml"; 
            
            var XsdDoc = new XmlTextReader(XsdPath); 
            var XmlDoc = new XmlTextReader(XmlPath); 
            
            var WellFormed = true; 
            
            XmlDocument xDoc = new XmlDocument(); 
            try { 
                xDoc.Load(XmlDoc); 
            } 
            catch (XmlException Ex) { 
                WellFormed = false; 
            } 
            
            if (WellFormed & Validated(XmlDoc, XsdDoc)) { 
              //Do stuff with my well formed and validated XmlDocument instance... 
            } 
        } 
    } 
