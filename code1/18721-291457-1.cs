    List<MyFileType> files = new List<MyFileType>();
    foreach(XElelement fileElement in fileElements)
    {
      files.Add(new MyFileType()
        {     
          Prop1 = fileElement.Element("Prop1"), //assumes properties are elements
          Prop2 = fileElement.Element("Prop2"),
        }
    }
