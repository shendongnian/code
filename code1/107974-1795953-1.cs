    Uri baseUri = new Uri("http://hostname/path/");
    string relative = "/my subsite/my page.aspx?my=query";
    Uri test1 = new Uri(baseUri, relative);              // original string
    Uri test2 = new Uri(baseUri, relative.Substring(1)); // without 'root' char
    Uri test3 = new Uri(baseUri, "." + relative);        // with 'current' char
    
    Console.WriteLine(test1.OriginalString); // wrong
    Console.WriteLine(test2.OriginalString); // right!
    Console.WriteLine(test3.OriginalString); // right!
