    IEnumerable<XElement> allPeopleCounting = xmlDoc.Root.Elements(ns + "peopleCounting");
    var result = from a in allPeopleCounting
                 select new
                 {
                     _enter = a.Element(ns + "enter").Value.Trim(),
                     _exit = a.Element(ns + "exit").Value.Trim(),
                     _pass = a.Element(ns + "pass").Value.Trim()
                 };
    foreach (var item in result)
    {
        Console.WriteLine(item._enter + " | " + item._exit + " | " + item._pass);
    }
