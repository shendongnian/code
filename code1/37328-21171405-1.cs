    Private String PrettyXML(string XMLString)
       {
          StringWriter sw = new StringWriter();
          XMLTextWriter xw = new XmlTextWriter(sw);
          xw.Formatiing = Formatting.Indented;
          xw.Indentation = 4;
          XmlDocument doc = new XmlDocument();
          doc.Save(xm);
          return sw.ToString();
       }
