    Console.Write("Enter file location: ");
    string fileLocation = Console.ReadLine();
    // Ensure the file exists
    while (!File.Exists(fileLocation))
    {
        Console.Write("File not found, please try again: ");
        fileLocation = Console.ReadLine();
    }
    // Read all the lines, split on the ':' character, into a list
    List<string> accountList = File.ReadAllLines(fileLocation)
        .SelectMany(line => line.Split(':'))
        .ToList();
