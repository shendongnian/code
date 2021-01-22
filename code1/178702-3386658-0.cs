    public static string GetPascalCase(string name)
    {
        return Regex.Replace(name, @"^\w|_\w", 
            (match) => match.Value.Replace("_", "").ToUpper());
    }
    Console.WriteLine(GetPascalCase("price_old")); // => Should be PriceOld
    Console.WriteLine(GetPascalCase("rank_old" )); // => Should be RankOld
