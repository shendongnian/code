    class X
    {
        public void SetInT(double newInT)
        {
            if (newInT != _inT)
            {
                _inT = newInT;
                Changed();//includes delegate call; potentially expensive
            }
        }
        
        private double _inT;
        
        public double InT
        {
            get { return InT; }
        }
        public XElement SerializeX()
        {
            XElement serializedItems = new XElement("X",
                new XElement("InT", this._inT),
                new XElement("OtherProperty1", this.OtherProperty1),
                new XElement("OtherProperty2", this.OtherProperty2));
            return serializedItems;
        }
        public void DeserializeX(XElement itemXML)
        {
            this._inT = Double.Parse(itemXML.Element("InT").Value,
                CultureInfo.InvariantCulture);
            this.OtherProperty1 = Double.Parse(
                itemXML.Element("OtherProperty1").Value,
                CultureInfo.InvariantCulture);
            this.OtherProperty2 = Double.Parse(
                itemXML.Element("OtherProperty2").Value,
                CultureInfo.InvariantCulture);
        }
    }
