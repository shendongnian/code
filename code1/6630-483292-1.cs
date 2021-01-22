    XmlDocument xdocDico = new XmlDocument();
    string sXMLfile;
    public loadDico(string sXMLfile, [other args...])
    {
       xdocDico.load(sXMLfile);
       // Gather whatever you need and load it into your dico
    }
    public flushDicInXML(string sXMLfile, dictionary dicWhatever)
    {
       // Dump the dic in the XML doc & save
    }
    public updateXMLDOM(index, key, value)
    {
       // Update a specific value of the XML DOM based on index or key
    }
