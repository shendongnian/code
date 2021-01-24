    string input;
    do {
        Console.WriteLine("Enter 3 words seperated by spaces: ");
        input = Console.ReadLine();
        if (input != "") {
            ConvertToPascal(input);
        }
    } while(input != "");
