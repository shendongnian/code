    public static string  GetMostLikelyType(List<string> inputs)
    {
        int num;
        double d;
        DateTime dt;
        bool b;
        TimeSpan ts;
        DateTimeOffset dto;
        if (inputs.All(i => int.TryParse(i, out num)))
            return "int";
        else if (inputs.All(i => double.TryParse(i, out d)))
            return "double";
        else if (inputs.All(i => DateTime.TryParse(i, out dt)))
            return "DateTime";
        else if (inputs.All(i => bool.TryParse(i, out b)))
            return "bool";
        else if (inputs.All(i => TimeSpan.TryParse(i, out ts)))
            return "TimeSpan";
        else if (inputs.All(i => DateTimeOffset.TryParse(i, out dto)))
            return "DateTimeOffset";
        else return "string";
    }
