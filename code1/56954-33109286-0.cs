        public sealed class HeaderSection: ConfigurationElement {
          private string __Name, __CDATA;
          [ConfigurationProperty("name", IsRequired = true)]
          public string Name {
            get {
              return this.__Name;
            }
            set {
              this.__Name = value;
            }
          }
          [ConfigurationProperty("value", IsRequired = true)]
          public string Value {
            get {
              return this.__CDATA;
            }
            set {
              this.__CDATA = value;
            }
          }
          protected override void DeserializeElement(System.Xml.XmlReader reader, bool s) {
            this.Name = reader.GetAttribute("name").Trim();
            string cdata = reader.ReadElementContentAs(typeof(string), null) as string;
            this.Value = cdata.Trim();
          }
        }
