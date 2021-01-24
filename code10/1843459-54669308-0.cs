    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    [XmlRoot("invoice")]
    public class Invoice
    {
        public Items items { get; set; }
    }
    [XmlRoot("item", Namespace = "")]
    public partial class InvoiceExampleItem
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("name", StringComparison.Ordinal))
                    {
                        reader.Read();
                        this.Name = reader.Value;
                        return;
                    }
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("name", this.Name);
        }
    }
    public class Items : IXmlSerializable
    {
        [XmlElement("item")]
        public List<InvoiceExampleItem> list = new List<InvoiceExampleItem>();
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            while (reader.ReadToFollowing("item"))
            {
                InvoiceExampleItem currentItem = new InvoiceExampleItem();
                currentItem.Name = reader.Value;
                list.Add(currentItem);
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            foreach(InvoiceExampleItem item in list)
            {
                writer.WriteStartElement("item");
                item.WriteXml(writer);
                writer.WriteEndElement();
            }
        }
    }
        [TestClass]
        public class ExampleTest : AutoMoqTest
        {
            [TestMethod]
            public void ExampleDeserialization()
            {
                /**/
                InvoiceExampleItem item1 = new InvoiceExampleItem()
                {
                    Name = "item1"
                };
                InvoiceExampleItem item2 = new InvoiceExampleItem()
                {
                    Name = "item2"
                };
                InvoiceExampleItem item3 = new InvoiceExampleItem()
                {
                    Name = "item3"
                };
            Items items = new Items();
            InvoiceExampleItem item21 = new InvoiceExampleItem()
            {
                Name = "item1"
            };
            InvoiceExampleItem item22 = new InvoiceExampleItem()
            {
                Name = "item2"
            };
            InvoiceExampleItem item23 = new InvoiceExampleItem()
            {
                Name = "item3"
            };
            items.list.Add(item21);
            items.list.Add(item22);
            items.list.Add(item23);
            Invoice mockInvoice = new Invoice()
                {
                    items = items
            };
                /**/
                XmlDocument mockInvoiceSerialized = SerializeInvoice(mockInvoice);
                
                XmlDocument mockResponseXml = GenerateXmlResponse(mockInvoiceSerialized);
            GetInvoiceResponse test = new GetInvoiceResponse();
                GetInvoiceResponse response = DeserializeXML<GetInvoiceResponse>(mockResponseXml.OuterXml);
                Invoice resultInvoice = response.Invoice;
            mockResponseXml.Save("C:\\Users\\360Imprimir\\Desktop\\mockResponseXml");
            mockInvoiceSerialized.Save("C:\\Users\\360Imprimir\\Desktop\\mockInvoiceSerialized.Xml");
            if (mockInvoice.items.list.Count != resultInvoice.items.list.Count)
                {
                    throw new Exception("wrong number of items");
                }
            }
            public XmlDocument SerializeInvoice(Invoice invoiceToSerialize)
            {
                XmlDocument toReturn = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(typeof(Invoice));
                XmlReaderSettings settings = new XmlReaderSettings();
                XmlDocument itemsDocument = GetTemplateXML();
                MemoryStream memStm = null, tempStream = null;
                try
                {
                    memStm = tempStream = new MemoryStream();
                    using (StreamWriter sw = new StreamWriter(memStm, Encoding.UTF8))
                    {
                        // Serialize object into raw xml
                        memStm = null;
                        serializer.Serialize(sw, invoiceToSerialize);
                        sw.Flush();
                        // parse raw xml into Xml document
                        tempStream.Position = 0;
                        settings.IgnoreWhitespace = true;
                        var xtr = XmlReader.Create(tempStream, settings);
                        toReturn.Load(xtr);
                    }
                }
                finally
                {
                    if (memStm != null)
                    {
                        memStm.Dispose();
                    }
                }
                return toReturn;
            }
            public static T DeserializeXML<T>(string responseString)
                where T : class
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                using (StringReader sr = new StringReader(responseString))
                {
                    return (T)xmlSerializer.Deserialize(sr);
                }
            }
            public XmlDocument GetTemplateXML()
            {
                XmlDocument toReturn = new XmlDocument();
                var decl = toReturn.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
                toReturn.AppendChild(decl);
                return toReturn;
            }
            private XmlDocument GenerateXmlResponse(XmlDocument innerXMLDocument)
            {
                XmlDocument toReturn = GetTemplateXML();
                XmlElement requestElement = toReturn.CreateElement("response");
                requestElement.SetAttribute("status", "success");
                requestElement.InnerXml = innerXMLDocument.DocumentElement.OuterXml;
                toReturn.AppendChild(requestElement);
                return toReturn;
            }
            /// <summary>
            /// Web response from creating a invoice
            /// </summary>
            [System.Xml.Serialization.XmlTypeAttribute(Namespace = "")]
            [System.Xml.Serialization.XmlRootAttribute(Namespace = "", ElementName = "response")]
            public class GetInvoiceResponse
            {
                /// <summary>
                /// Gets or sets the response status
                /// </summary>
                /// <value>
                /// reponse Status
                /// </value>
                [XmlAttribute("status")]
                public string ResponseStatus { get; set; }
                /// <summary>
                /// Gets or sets the new invoice id
                /// </summary>
                /// <value>
                /// generated by invoicera for this response
                /// </value>
                [XmlElement(ElementName = "invoice")]
                public Invoice Invoice { get; set; }
            }
        }
