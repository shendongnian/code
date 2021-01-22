    private void readXML() {
        XmlReaderSettings settings = new XmlReaderSettings();
        //configure xml reader settings...
        using(XmlReader reader = XmlReader.Create("file.xml", settings)){
            while (reader.Read()){
                //read xml content..
            }
            reader.Close();
        }
    }
