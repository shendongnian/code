        System.Xml.Xsl.XslCompiledTransform textTransform = new System.Xml.Xsl.XslCompiledTransform();
        textTransform.Load("CopyTransform.xsl"); //the saved version of the sample above
        System.Xml.XmlReaderSettings strangeNewSecurityRequirementSetting = new System.Xml.XmlReaderSettings();
        strangeNewSecurityRequirementSetting.ProhibitDtd = false; //I don't know the security consequences of this, you probably want to look it up.
        System.Xml.XmlReader wonkyXHTMLReader = System.Xml.XmlReader.Create("testin.xml", strangeNewSecurityRequirementSetting);
        System.Xml.XmlWriter nicerXHTMLWriter = System.Xml.XmlWriter.Create("testout.html");
        textTransform.Transform(wonkyXHTMLReader, nicerXHTMLWriter);
        nicerXHTMLWriter.Close();
