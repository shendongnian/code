    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="FileNexusKey", Namespace="http://www.jboss.org/store")]
    	public class FileNexusKey 
        {
    		[XmlElement(ElementName="TransRefGUID", Namespace="http://www.jboss.org/store")]
    		public string TransRefGUID { get; set; }
    		[XmlElement(ElementName="CertificateNumber", Namespace="http://www.jboss.org/store")]
    		public string CertificateNumber { get; set; }
    		[XmlElement(ElementName="DocumentType", Namespace="http://www.jboss.org/store")]
    		public string DocumentType { get; set; }
    		[XmlElement(ElementName="DocumentSubType", Namespace="http://www.jboss.org/store")]
    		public string DocumentSubType { get; set; }
    		[XmlElement(ElementName="DocumentID", Namespace="http://www.jboss.org/store")]
    		public string DocumentID { get; set; }
    		[XmlElement(ElementName="DOB", Namespace="http://www.jboss.org/store")]
    		public string DOB { get; set; }
    		[XmlElement(ElementName="ClientFirstName", Namespace="http://www.jboss.org/store")]
    		public string ClientFirstName { get; set; }
    		[XmlElement(ElementName="ClientLastName", Namespace="http://www.jboss.org/store")]
    		public string ClientLastName { get; set; }
    	}
    
    	[XmlRoot(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    	public class Body 
        {
    		[XmlElement(ElementName="FileNexusKey", Namespace="http://www.jboss.org/store")]
    		public FileNexusKey FileNexusKey { get; set; }
    	}
    
    	[XmlRoot(ElementName="Envelope", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    	public class Envelope 
        {
    		[XmlElement(ElementName="Header", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    		public string Header { get; set; }
    		[XmlElement(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    		public Body Body { get; set; }
    		[XmlAttribute(AttributeName="stor", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Stor { get; set; }
    		[XmlAttribute(AttributeName="soapenv", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Soapenv { get; set; }
    	}
    }
