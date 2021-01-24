    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.IO;
    using System.Xml;
    using System.Text;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Soap;
    using System.Web.Script.Services;
    using System.Xml.Serialization;
    
    namespace AB_TestWebApp
    {
        /// <summary>
        /// Zusammenfassungsbeschreibung für WebService1
        /// </summary>
        [WebService(Namespace = "http://cpu1147/AB_TestWebApp/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(true)]
        // Wenn der Aufruf dieses Webdiensts aus einem Skript zulässig sein soll, heben Sie mithilfe von ASP.NET AJAX die Kommentarmarkierung für die folgende Zeile auf. 
        [System.Web.Script.Services.ScriptService]
        public class WebService1 : System.Web.Services.WebService
        {
    
    
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
            public string AddTwoStr()
            {
                //--//
                // Get raw request body
                Stream receiveStream = HttpContext.Current.Request.InputStream;
                // Move to begining of input stream and read
                receiveStream.Position = 0;
                //Webrequest als StreamReader
                //StreamReader mystream = new StreamReader(receiveStream, Encoding.UTF8);
                //StreamReader mystream = new StreamReader(receiveStream);
    
                //string test = mystream.ReadToEnd();
    
                //XmlDocument document = new XmlDocument();
                //document.LoadXml(test);
                //XElement xdocument = XElement.Parse(test);
    
                Envelope data;
                //var xml = document.Value;
    
                //using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(receiveStream.ToString())))
                using (StreamReader stream = new StreamReader(receiveStream, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                    data = (Envelope)serializer.Deserialize(stream);
                }
    
                //Access the parameters here via an index.
                string String1 = data.Body.AddTwoStr.InputParameters[0].Value;
                string String2 = data.Body.AddTwoStr.InputParameters[1].Value;
    
                //--//
    
                XElement sofon_response = new XElement("Parameter",
                new XElement("DataType", "String"),
                new XElement("Name", "WebResponse"),
                new XElement("Value", string.Concat(String1, String2))
                );
    
                return sofon_response.ToString();
            }
    
    
            [WebMethod]
            public string HelloWorld()
            {
                return "Hello World";
            }
    
    
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
            public partial class Envelope
            {
    
                private EnvelopeBody bodyField;
    
                /// <remarks/>
                public EnvelopeBody Body
                {
                    get
                    {
                        return this.bodyField;
                    }
                    set
                    {
                        this.bodyField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public partial class EnvelopeBody
            {
    
                private AddTwoStrPar addTwoStrField;
    
                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://cpu1147/AB_TestWebApp/")]
                public AddTwoStrPar AddTwoStr
                {
                    get
                    {
                        return this.addTwoStrField;
                    }
                    set
                    {
                        this.addTwoStrField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://cpu1147/AB_TestWebApp/")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://cpu1147/AB_TestWebApp/", IsNullable = false)]
            public partial class AddTwoStrPar
            {
    
                private AddTwoStrParameter[] inputParametersField;
    
                /// <remarks/>
                [System.Xml.Serialization.XmlArrayItemAttribute("Parameter", IsNullable = false)]
                public AddTwoStrParameter[] InputParameters
                {
                    get
                    {
                        return this.inputParametersField;
                    }
                    set
                    {
                        this.inputParametersField = value;
                    }
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://cpu1147/AB_TestWebApp/")]
            public partial class AddTwoStrParameter
            {
    
                private string dataTypeField;
    
                private string nameField;
    
                private string valueField;
    
                /// <remarks/>
                public string DataType
                {
                    get
                    {
                        return this.dataTypeField;
                    }
                    set
                    {
                        this.dataTypeField = value;
                    }
                }
    
                /// <remarks/>
                public string Name
                {
                    get
                    {
                        return this.nameField;
                    }
                    set
                    {
                        this.nameField = value;
                    }
                }
    
                /// <remarks/>
                public string Value
                {
                    get
                    {
                        return this.valueField;
                    }
                    set
                    {
                        this.valueField = value;
                    }
                }
            }
        }
    }
