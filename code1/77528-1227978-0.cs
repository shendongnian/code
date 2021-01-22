        ...
        [XmlArray(IsNullable = false)]
        [XmlArrayItem("MyInnerObjectProperties")]
        public MyObject[] MyObjectProperty
        {
            get
            {
                return _myObjectProperty;
            }
            set
            {
                _myObjectProperty = value;
            }
        }
        ...
