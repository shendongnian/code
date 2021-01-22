    XElement docEmpty = XElement.Parse("<p><br /></p>");
    Console.WriteLine(string.IsNullOrEmpty(docEmpty.Value)); // Outputs True.
    
    XElement doc = XElement.Parse("<p>This is a test<br /></p>");
    Console.WriteLine(string.IsNullOrEmpty(doc.Value)); // Outputs False.
