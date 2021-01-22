    public ResultStruct HandleMessage(IParserInput input) 
    {
        IParser parser = input.GetParser();
        Map<string,string> parameters = parser.Parse(input);
        ICommand command = input.GetCommand();
        return command.Execute(parameters);
    }
