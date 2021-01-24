    public string formatValue(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "Empty";
        }
        else if (input == "Pending")
        {
            return "Is pending";
        }
        else
        {
            return "Available";
        }
    }
