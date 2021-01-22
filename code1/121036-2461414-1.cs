    [XmlAttribute("AccountExpirationDate")]  
    public SerDateTime AccountExpirationDate   
    {   
      get { return _SerDateTime ; }   
      set { _SerDateTime = value; }   
    }  
    /// <summary>
    /// Serialize DateTime Class (<i>yyyy-mm-dd</i>)
    /// </summary>
    public class SerDateTime : IXmlSerializable {
        /// <summary>
        /// Default Constructor when time is not avalaible
        /// </summary>
        public SerDateTime() { }
        /// <summary>
        /// Default Constructor when time is avalaible
        /// </summary>
        /// <param name="pDateTime"></param>
        public SerDateTime(DateTime pDateTime) {
            DateTimeValue = pDateTime;
        }
        private DateTime? _DateTimeValue;
        /// <summary>
        /// Value
        /// </summary>
        public DateTime? DateTimeValue {
            get { return _DateTimeValue; }
            set { _DateTimeValue = value; }
        }
        // Xml Serialization Infrastructure
        void IXmlSerializable.WriteXml(XmlWriter writer) {
            if (DateTimeValue == null) {
                writer.WriteString(String.Empty);
            } else {
                writer.WriteString(DateTimeValue.Value.ToString("yyyy-MM-dd"));
                //writer.WriteString(SerializeObject.SerializeInternal(DateTimeValue.Value));
            }
        }
        void IXmlSerializable.ReadXml(XmlReader reader) {
            reader.ReadStartElement();
            String ltValue = reader.ReadString();
            reader.ReadEndElement();
            if (ltValue.Length == 0) {
                DateTimeValue = null;
            } else {                
                //Solo se admite yyyyMMdd
                //DateTimeValue = (DateTime)SerializeObject.Deserialize(typeof(DateTime), ltValue);
                DateTimeValue = new DateTime(Int32.Parse(ltValue.Substring(0, 4)),
                                    Int32.Parse(ltValue.Substring(5, 2)),
                                    Int32.Parse(ltValue.Substring(8, 2)));                                    
            }
        }
        XmlSchema IXmlSerializable.GetSchema() {
            return (null);
        }
    }
    #endregion
