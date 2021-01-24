    class Program
        {
            static void Main(string[] args)
            {
    
                using (var sreader = new StringReader(File.ReadAllText(@"C:\Users\JP\source\repos\soXmlParsing\soXmlParsing\XMLFile1.xml")))
                using (var reader = XmlReader.Create(sreader))
                {
                    var serializer = new XmlSerializer(typeof(customer));
                    var test = (customer)serializer.Deserialize(reader);
                    Console.WriteLine(test.PARENTNAME);
                    Console.WriteLine(test.DISPLAYCONTACTCONTACTNAME);
                }
            }
        }
    
    
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class customer
        {
    
            private byte rECORDNOField;
    
            private string cUSTOMERIDField;
    
            private string pARENTNAMEField;
    
            private string dISPLAYCONTACTCONTACTNAMEField;
    
            private string dISPLAYCONTACTCOMPANYNAMEField;
    
            /// <remarks/>
            public byte RECORDNO
            {
                get
                {
                    return this.rECORDNOField;
                }
                set
                {
                    this.rECORDNOField = value;
                }
            }
    
            /// <remarks/>
            public string CUSTOMERID
            {
                get
                {
                    return this.cUSTOMERIDField;
                }
                set
                {
                    this.cUSTOMERIDField = value;
                }
            }
    
            /// <remarks/>
            public string PARENTNAME
            {
                get
                {
                    return this.pARENTNAMEField;
                }
                set
                {
                    this.pARENTNAMEField = value;
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("DISPLAYCONTACT.CONTACTNAME")]
            public string DISPLAYCONTACTCONTACTNAME
            {
                get
                {
                    return this.dISPLAYCONTACTCONTACTNAMEField;
                }
                set
                {
                    this.dISPLAYCONTACTCONTACTNAMEField = value;
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("DISPLAYCONTACT.COMPANYNAME")]
            public string DISPLAYCONTACTCOMPANYNAME
            {
                get
                {
                    return this.dISPLAYCONTACTCOMPANYNAMEField;
                }
                set
                {
                    this.dISPLAYCONTACTCOMPANYNAMEField = value;
                }
            }
        }
