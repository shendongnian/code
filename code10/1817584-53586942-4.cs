    private void ProcessInput(string input)
    {
        if(string.IsNullOrEmpty(input)) throw new ArgumentException();
        input = input.Trim().ToLower();
        if(input == "exit" || input == "leave")
        {
            Console.Clear();
            ExitProgram.ExitProg();
            calcInput = false;
        }
        else if(input == "back" || input == "menu")
        {
            TxtFun.CTxt("Returning to previous menu.");
            Console.ReadLine();
            Console.Clear();
            calcInput = false;
            calcLoop = false;
        }
        else
        {
            TxtFun.CTxt("Invalid input.");
            Console.ReadLine();
            Console.Clear();
        
            calcInput = false;
        }    
    }
