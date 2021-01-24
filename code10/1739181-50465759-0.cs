    private static void UpdateXML(string xmlpath, string studentName, int age)
    {
        var doc = XDocument.Load(xmlpath);
    
        //Get student
        var student = doc.Descendants("student").Where(att => att.Element("name") != null && att.Element("name").Value.Equals(studentName)).FirstOrDefault();
        if (student != null)
            student.Element("age").Value = age.ToString();
        doc.Save(xmlpath);
    }
