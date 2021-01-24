    XDocument xmlDoc = XDocument.Parse(s1);
    XNamespace ns = "urn:psialliance-org";
    XElement peopleCounting = xmlDoc.Root.Element(ns + "peopleCounting");
    string enter = peopleCounting.Element(ns + "enter").Value.Trim(); // Remove spaces from the value
    string exit = peopleCounting.Element(ns + "exit").Value.Trim();
    string pass = peopleCounting.Element(ns + "pass").Value.Trim();
    Console.WriteLine(enter + " | " + exit + " | " + pass);
