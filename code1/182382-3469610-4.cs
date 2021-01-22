    static void TestRegularExpression()
    {
        String line = "Some text here, blah blah Identity=\"EDN\\nuckol\" and FRAMEworkSiteID=\"DesotoGeneral\" and other stuff.";
        Match m1 = Regex.Match(line, "((identity)(=)('|\")([a-zA-Z]*)([\\\\]*)([a-zA-Z]*)('|\"))", RegexOptions.IgnoreCase);
        Match m2 = Regex.Match(line, "((frameworkSiteID)(=)('|\")([a-zA-Z]*)('|\"))", RegexOptions.IgnoreCase);
    
        if (m1.Success && m2.Success)
        {
            //...
            Console.WriteLine("Success!");
            Console.ReadLine();
        }
    }
