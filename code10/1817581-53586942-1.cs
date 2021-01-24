    private void ProcessExitInput(string input)
    {
        if(input == "exit" || input == "leave")
        {
            Console.Clear();
            ExitProgram.ExitProg();
            calcInput = false;
        }
    }
    private void ProcessMenuInput(string input)
    {
        if(input == "back" || input == "menu")
        {
            TxtFun.CTxt("Returning to previous menu.");
            Console.ReadLine();
            Console.Clear();
            calcInput = false;
            calcLoop = false;
        }
    }
    private void ProcessDefaultInput(string input)
    {
        if(input != "back" && input != "menu" && input != "exit" && input != "leave")
        {
            TxtFun.CTxt("Returning to previous menu.");
            Console.ReadLine();
            Console.Clear();
            calcInput = false;
            calcLoop = false;
        }
    }
