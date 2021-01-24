    foreach (var item in coinData.OfType<JProperty>()) {
        string coinName = item.Name;
        // to parse as decimal
        decimal price = item.Value.Value<decimal>();
        // or as string
        string priceAsString = item.Value.Value<string>();
    }
