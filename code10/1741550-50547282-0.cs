    var anchors = document.QuerySelectorAll("a").OfType<IHtmlAnchorElement>();
    foreach (var a in anchors)
    {
        Console.WriteLine(a.Text); // prints the link inner text
        Console.WriteLine("Href = " + GetAttribute("href")); // prints all the links
    }
    // if you are using winforms then replace console.writeline with string text
