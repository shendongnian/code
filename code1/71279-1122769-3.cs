        public class Quote
        {
            public string symbol;
            public double price;
            public double change;
            public int volume;
        }
        
        public void Run()
        {
            Quote q = new Quote
                {
                    symbol = "fff",
                    price = 19.86,
                    change = 1.23,
                    volume = 190393,
                    };
            WriteDocument(q);
        }
      
      
        public void WriteDocument(Quote q) 
        {
            var settings = new System.Xml.XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Indent= true
                };
            using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
            {
                writer.WriteStartElement("Stock");
                writer.WriteAttributeString("Symbol", q.symbol);
                writer.WriteElementString("Price", XmlConvert.ToString(q.price));
                writer.WriteElementString("Change", XmlConvert.ToString(q.change));
                writer.WriteElementString("Volume", XmlConvert.ToString(q.volume));
                writer.WriteEndElement();
            }
        }
