    public string FindStudentID(string fullName)
    {
       string result = string.Empty;
       XmlDocument doc = new XmlDocument();
       doc.Load(@"your-xml-file-name.xml");
     
       string xpath = string.Format("/Students/Student[FullName='{0}']", fullName);
       XmlNode node = doc.SelectSingleNode(xpath);
    
       if (node != null)  // we found John Smith
       {
          result = node.Attributes["ID"].Value;
       }
       return result;
    }
