    public void ExecuteCommand (string commandText)
    {
        var match = Regex.Match(commandText, @"$(\w+)\s*(.*)^");
        if (match.Success)
        {
            string keyword = match.Groups[1].Value;
            string parameters = match.Groups[2].Value;
            switch (keyword)
            {
            case "function":
                MyFunction(parameters);
                break;
            default:
                throw new NotImplementedException();
            }
        }
    }
