    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string result = File.ReadAllText(FILENAME);
                StringReader sReader = new StringReader(result);
                SOAPEnvelope deserializedObject;
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                using (XmlReader reader = XmlReader.Create(sReader))
                {
                    
                    var ser = new XmlSerializer(typeof(SOAPEnvelope));
                    deserializedObject = (SOAPEnvelope)ser.Deserialize(reader);
                }
            }
        }
        [XmlType(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        [XmlRoot(ElementName = "Envelope", Namespace ="http://schemas.xmlsoap.org/soap/envelope/")]
        public class SOAPEnvelope
        {
            [XmlAttribute(AttributeName = "soapenv", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public string soapenv { get; set; }
            [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2001/XMLSchema")]
            public string xsd { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string xsi { get; set; }
            [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public ResponseBody<GetOrderInfoResponse> body { get; set; }
            [XmlNamespaceDeclarations]
            public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        }
        [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class ResponseBody<T>
        {
            [XmlElement(ElementName = "getOrderInfoResponse", Namespace = "http://webservice.integrator.hkpost.com")]
            public T getOrderInfoResponse { get; set; }
        }
        [XmlRoot(ElementName = "getOrderInfoResponse", Namespace = "http://webservice.integrator.hkpost.com")]
        public class GetOrderInfoResponse
        {
            [XmlElement(ElementName = "getOrderInfoReturn", Namespace = "http://webservice.integrator.hkpost.com")] 
            public GetOrderInfoReturn  getOrderInfoReturn { get; set; }
        }
        [XmlRoot(ElementName = "getOrderInfoResponse", Namespace = "http://webservice.integrator.hkpost.com")]
        public class GetOrderInfoReturn
        {
            [XmlElement(ElementName = "additionalDocument", Namespace = "http://webservice.integrator.hkpost.com")]
            public string additionalDocument { get; set; }
            [XmlElement(ElementName = "certificateQty", Namespace = "http://webservice.integrator.hkpost.com")]
            public int certificateQty { get; set; }
            [XmlElement(ElementName = "deliveryCharge", Namespace = "http://webservice.integrator.hkpost.com")]
            public decimal deliveryCharge { get; set; }
        }
    }
