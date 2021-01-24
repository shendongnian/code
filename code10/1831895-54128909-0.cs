    static void Main(string[] args)
    {
        string[] inputs =
        {
            "$1.30",
            "£1.50",
            "€2,50",
            "2,50 €",
            "2.500,00 €"
        };
        for (int i = 0; i < inputs.Length; i++)
        {
            Console.Write((i + 1).ToString() + ". ");
            if (decimal.TryParse(inputs[i], NumberStyles.Currency,
                                 GetAppropriateCulture(inputs[i]), out var parsed))
            {
                Console.WriteLine(parsed);
            }
            else
            {
                Console.WriteLine("Can't parse");
            }
        }
    }
    
    private static CultureInfo GetAppropriateCulture(string input)
    {
        if (input.StartsWith("$")) 
            return CultureInfo.CreateSpecificCulture("en-US");
        if (input.StartsWith("£")) 
            return CultureInfo.CreateSpecificCulture("en-GB");
        if (input.StartsWith("€") || input.EndsWith("€")) 
            return CultureInfo.CreateSpecificCulture("de-DE");
        return CultureInfo.InvariantCulture;
    }
