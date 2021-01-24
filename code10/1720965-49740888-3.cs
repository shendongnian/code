            private static void button1_click()
        {
            var xmlSerializer = new XmlSerializer(typeof(eAction));
            var xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("cation", "http://www.caction.org/standards/pc_go/xml/");
            xmlNameSpace.Add("acme", "http://www.ACME.org/standards/ACME1/xml/");
            xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            using (var txtWriter = new StreamWriter(@"C:\temp\actionout.xml"))
            {
                var eActionItem = new eAction();
                xmlSerializer.Serialize(txtWriter, eActionItem, xmlNameSpace);
            }
        }
