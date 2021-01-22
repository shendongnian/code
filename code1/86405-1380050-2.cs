       private string _message;
       [XmlElement("CDataElement")]
       public XmlCDataSection Message
       {  
          get 
          { 
             XmlDocument doc = new XmlDocument();
             return doc.CreateCDataSection( _message);
          }
          set
          {
             _message = value.Value;
          }
       }
