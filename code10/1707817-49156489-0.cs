    var splittedString = time.Split(':');
    // All parts, glued with a comma
    Console.WriteLine(string.Join(" , ", splittedString));
    // Only the first part
    Console.WriteLine(splittedString[0]);
