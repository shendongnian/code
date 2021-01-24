    public static (double Value, string unit) Parse(string value)
    {
        var values = value.Split(" ");
        double number;
        if (!double.TryParse(values[0], out number))
            throw new FormatException("Value cannot be parsed as a floating point number.");
        string unit = values[1];
        return (number, unit);
    }
