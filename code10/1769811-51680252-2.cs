    bool IsMessageUpper(string input)
    {
        int x = (input ?? "").Length;
        return x>=7 && x<= 10 && input.Count(char.IsUpper) >= 7;
    }
