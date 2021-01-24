    Console.WriteLine("Are You Sure Your User: " + user + " And Pass: " + Pass + " is correct?  Yes/No");
    var input = Console.ReadLine();
    if (input == "Yes" || input == "yes")
    {
       Console.WriteLine("You May now close this");
    }
    else if(input == "No" || input == "no")
    {
       Console.WriteLine("Pleas Press enter");
       System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0], Environment.GetCommandLineArgs().Length > 1 ? string.Join(" ", Environment.GetCommandLineArgs().Skip(1)) : null);
    }
