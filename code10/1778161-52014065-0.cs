    oldPriceMap = oldPrice.ToDictionary(p => p.ASIN, p => p);
    foreach (var item in allItems) {
        if (oldPriceMap.Cotains(item.ASIN)) {
            // change something on current item
            item.ASIN = "one and two";
        }
    }
