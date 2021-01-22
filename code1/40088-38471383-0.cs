    public static string UnCamelCase(this Enum input, string delimiter = " ", bool preserveCasing = false)
    {
        var characters = input.ToString().Select((x, i) =>
        {
           if (i > 0 && char.IsUpper(x))
           {
               return delimiter + x.ToString(CultureInfo.InvariantCulture);
           }
           return x.ToString(CultureInfo.InvariantCulture);
        });
        var result = preserveCasing
           ? string.Concat(characters)
           : string.Concat(characters).ToLower();
        var lastComma = result.LastIndexOf(", ", StringComparison.Ordinal);
        if (lastComma > -1)
        {
           result = result.Remove(lastComma, 2).Insert(lastComma, " and ");
        }
        return result;
    }
