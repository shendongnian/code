    public class SerializableClass : XmlSerializableBase
    {
        public string Title { get; set; } = "Test title";
        public string Description { get; set; } = "Super description";
        public int Number { get; set; } = (int)(DateTime.Now.Ticks % 99);
		
		protected override void Populate(XElement element)
		{
			this.Title = (string)element.Element(nameof(this.Title));
			this.Description = (string)element.Element(nameof(this.Description));
			// Leave Number unchanged if not present in the XML
			this.Number = (int?)element.Element(nameof(this.Number)) ?? this.Number;  
		}
		
        public override void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement(nameof(this.Title));
            writer.WriteString(this.Title);
            writer.WriteEndElement();
            writer.WriteStartElement(nameof(this.Description));
            writer.WriteString(this.Description);
            writer.WriteEndElement();
            writer.WriteStartElement(nameof(this.Number));
			// Do not use ToString() as it is locale-dependent.  
			// Instead use XmlConvert.ToString(), or just writer.WriteValue
            writer.WriteValue(this.Number);
            writer.WriteEndElement();
        }
    }
