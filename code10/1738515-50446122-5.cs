    private string GenerateNameFrom(IRow row)
    {
        string name = string.Empty;
        return Method1(name)
            ?? Method2(name)
            ?? Method3(name)
            ?? "Null";
    }
