    foreach (var item in coinData.OfType<JProperty>()) {
        string coinName = item.Name;
        // to parse as decimal
        decimal balance = item.Value.Value<decimal>();
        // or as string
        string balanceAsString = item.Value.Value<string>();
    }
