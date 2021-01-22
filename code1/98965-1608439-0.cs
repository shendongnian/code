     XDocument XDoc = XDocument.Parse(xfile);
     XNamespace ns = "PersonInstances";
     if (XDoc.Root.Descendants(ns + "PersonId").Any())
     {
        Console.Write(XDoc.Root.Descendants(ns + "PersonId").First().Value);
     }
     else
     {
        Console.Write("Fail");
     }
