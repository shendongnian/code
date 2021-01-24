    private static string TpdToString(ThirdPartyData input)
    {
        if (input == null) return null;
        var asinParts = input.ASIN?.Split(':') ?? new[] {"[NULL]"};
        var asin = asinParts.Length > 1 ? asinParts[1].Trim() : asinParts[0].Trim();
        return $"ASIN-{asin},type-{input.type},Price-{input.Price}," + 
            $"IsPrime-{input.IsPrime},OutOfStock-{input.OutOfStock}";
    }
