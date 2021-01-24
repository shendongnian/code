    string filePath = @"C:\FileMessageTemplates\Outright\"; //File path
    string path = Path.Combine(filePath ,"First_Test_1.xml");
    XDocument doc = XDocument.Load(path); //Loads document 
    var list = doc.Root.Elements("CatsId")
                       .Select(element => element.Value)
                       .ToList();
    foreach (string value in list)
    {
        Console.WriteLine(value);
    }
