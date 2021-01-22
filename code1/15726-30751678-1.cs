    decimal GetPrice(string productName)
    {
        decimal basePrice = CalculateBasePrice(productName);
        return basePrice;
    }
    decimal GetPrice(string productName, decimal discountPercentage)
    {
        if (discountPercentage <= 0)
            throw new ArgumentException();
        decimal basePrice = GetPrice(productName);
        decimal discountedPrice = basePrice * (1 - discountPercentage / 100);
        return discountedPrice;
    }
