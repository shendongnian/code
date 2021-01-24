    private static void ViewBalance()
    {
        ClearAndShowHeading("Account Balance");
        GoToMainMenu();
    }
    private static void Deposit()
    {
        ClearAndShowHeading("Account Deposit");
        GoToMainMenu();
    }
    private static void Withdraw()
    {
        ClearAndShowHeading("Account Withdrawl");
        GoToMainMenu();
    }
    private static void ClearAndShowHeading(string heading)
    {
        Console.Clear();
        Console.WriteLine(heading);
        Console.WriteLine(new string('-', heading?.Length ?? 0));
    }
    private static void GoToMainMenu()
    {
        Console.Write("\nPress any key to go to the main menu...");
        Console.ReadKey();
        MainMenu();
    }
