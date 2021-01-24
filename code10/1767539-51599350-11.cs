    string myString = "abc";
    string response = string.Empty;
    int index = 0;
    while (response.TrimEnd().ToUpper() != "END") {
        Console.WriteLine(GetCharacter(myString, index++));
        Console.WriteLine("If you wish to end the test please enter 'END'.");
        response = Console.ReadLine();
        if (index > myString.Length)
            index = 0;
    }
