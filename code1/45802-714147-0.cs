    string startPath = @"C:\Testing\Testing\bin\Debug";
    string[] oDirectories = Directory.GetDirectories(startPath, "xml", SearchOption.AllDirectories);
    Console.WriteLine(oDirectories.Length.ToString());
    foreach (string oCurrent in oDirectories)
        Console.WriteLine(oCurrent);
    Console.ReadLine();
