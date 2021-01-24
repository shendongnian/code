    public static IList<string> ExctractListId(string command)
    {
        if (command == null || !command.StartsWith("GET_LIST"))
        {
            return new List<string>();
        }
        int temp;
        return command.Split().Where(item => int.TryParse(item, out temp)).ToList();
    }
