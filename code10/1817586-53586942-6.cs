    private void ProcessInput(string input)
    {
        if(string.IsNullOrEmpty(input)) throw new ArgumentException();
        input = input.Trim().ToLower();
        ProcessExitInput(input);
        ProcessMenuInput(input);
        ProcessDefaultInput(input);
    }
