    string filename = @"C:\Temp\demo.xml";
    XDocument document = XDocument.Load(filename);
    var stepOnes = document.Descendants("Step").Where(e => e.Attribute("Test").Value == "SampleTestOne");
    foreach (XElement element in stepOnes)
    {
        if (element.Attribute("Status") != null)
            element.Attribute("Status").Value = "Pass";
        else
            element.Add(new XAttribute("Status", "Pass"));
    }
    document.Save(filename); 
