    MyTypeWithNamespaces myType = new MyTypeWithNamespaces("myLabel", 42);
    /******
       OK, I just figured I could do this to make the code shorter, so I commented out the
       below and replaced it with what follows:
    // You have to use this constructor in order for the root element to have the right namespaces.
    // If you need to do custom serialization of inner objects, you can use a shortened constructor.
    XmlSerializer xs = new XmlSerializer(typeof(MyTypeWithNamespaces), new XmlAttributeOverrides(),
        new Type[]{}, new XmlRootAttribute("MyTypeWithNamespaces"), "urn:Abracadabra");
    ******/
    XmlSerializer xs = new XmlSerializer(typeof(MyTypeWithNamespaces),
        new XmlRootAttribute("MyTypeWithNamespaces") { Namespace="urn:Abracadabra" });
    // I'll use a MemoryStream as my backing store.
    MemoryStream ms = new MemoryStream();
    // This is extra! If you want to change the settings for the XmlSerializer, you have to create
    // a separate XmlWriterSettings object and use the XmlTextWriter.Create(...) factory method.
    // So, in this case, I want to omit the XML declaration.
    XmlWriterSettings xws = new XmlWriterSettings();
    xws.OmitXmlDeclaration = true;
    xws.Encoding = Encoding.UTF8; // This is probably the default
    // You could use the XmlWriterSetting to set indenting and new line options, but the
    // XmlTextWriter class has a much easier method to accomplish that.
    // The factory method returns a XmlWriter, not a XmlTextWriter, so cast it.
    XmlTextWriter xtw = (XmlTextWriter)XmlTextWriter.Create(ms, xws);
    // Then we can set our indenting options (this is, of course, optional).
    xtw.Formatting = Formatting.Indented;
    
    // Now serialize our object.
    xs.Serialize(xtw, myType, myType.Namespaces);
