    //get user input
    Console.Write("Enter equation:");
    string input = Console.ReadLine();
    string[] splitInput = input.Split('=');
    int index = char.IsLetter(splitInput[0].Replace(" ", "")[0]) ? 1 : 0;
    string sideWithEquation = splitInput[index];
    
    //Compute right hand side
    string[] equation = sideWithEquation.Split(' ');
