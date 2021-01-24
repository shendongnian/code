    Dictionary<MenuSelection, string> dict = new Dictionary<MenuSelection, string>();
    dict.Add(MenuSelection.CreateCustomer, "Create Customer");
    dict.Add(MenuSelection.CreateAccount, "Create Account");
    dict.Add(MenuSelection.SetAccountBalance, "Set Account Balance");
    dict.Add(MenuSelection.DisplayAccountBalance, "Display Account Balance");
    dict.Add(MenuSelection.Exit, "Exit");
    
    string showValue = string.Empty;
    for (int i = 1; i <= (int)MenuSelection.MaxMenuSelection; i++)
    {
    	if (dict.TryGetValue((MenuSelection)i, out showValue))
    	{
    		Console.WriteLine($"[{i}] { showValue}");
    	}           
    }
