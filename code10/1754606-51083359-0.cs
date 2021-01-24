    string text = "Items Item 1, Item 2 in Boxes Box 1, Box 2";
    
    var match = Regex.Match(text, "^Items(?: ([^,]*),?)* in Boxes(?: ([^,]*),?)*$");
                
    System.Console.WriteLine("Items:");
    foreach (Capture cap in match.Groups[1].Captures)
        System.Console.WriteLine(cap.Value); // -->Item1 and Item2
    
    System.Console.WriteLine("Boxes:");
    foreach (Capture cap in match.Groups[2].Captures)
        System.Console.WriteLine(cap.Value); // --> Box 1 and Box 2
