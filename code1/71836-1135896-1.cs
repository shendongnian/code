        #endregion
        #region IEnumerable Members
        ...
        #endregion
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
           //TODO
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            foreach (IAction oAction in List)
            {       
                    XmlSerializer s = new XmlSerializer(oAction.GetType());
                    s.Serialize(writer, oAction);
            }
        }
        #endregion
    }
