    // I just wanted to show explicitly setting all the properties to null...
    MyClassWithNullableProp myClass = new MyClassWithNullableProp( ) {
        Property1 = null,
        MyNullableInt = null,
        MyEmptyString = null,
        MyEmptyNullableFloat = null
    };
    // Serialize it.
    // You'll need to setup some backing store for the text writer below...
    // a file, memory stream, something...
    XmlTextWriter writer = XmlTextWriter(...) // Instantiate a text writer.
    XmlSerializer xs = new XmlSerializer(typeof(MyClassWithNullableProp),
        new XmlRootAttribute("MyClassWithNullableProp") { 
            Namespace="urn:myNamespace", 
            IsNullable = false
        }
    );
    xs.Serialize(writer, myClass, myClass.Namespaces);
