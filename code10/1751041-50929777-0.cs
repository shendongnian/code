    var byItemCode = _AnalsisCodes
        .GroupBy(w => w.ItemCode)
        .ToDictionary(g => g.Key, g => g.First());
    ...
    foreach (var item in tradeItem) {
        if (byItemCode.TryGetValue(item.ItemCode, out var codesForThisItem) && codesForThisItem.Any()) {
            ...
        }
    }
