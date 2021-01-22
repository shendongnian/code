     [XmlArrayItemAttribute("MyInnerObjectProperty", typeof(MyInnerObject),  IsNullable = false)]
             public MyInnerObject[] MyInnerObjectProperties
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
