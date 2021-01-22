    [XmlArray("MyInnerObjectProperties")]     
    [XmlArrayItemAttribute("MyInnerObjectProperty", typeof(MyInnerObject),  IsNullable = false)]
    public MyInnerObject[] MyInnerObjectProperty
    {
       get
         {
             return _myInnerObjectProperty;
         }
       set
         {
            _myInnerObjectProperty = value;
         }
    }
