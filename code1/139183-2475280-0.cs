    public List<Product> SetFeatures(List<Product> products, int numberOfFeatures)
    {
        return products
            .GroupBy(p => p.ManufacturerId)
            .Take(numberOfFeatures)
            .Select(g => g.First());
    }
