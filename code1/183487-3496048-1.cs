    // bestPrice is array of best prices for each amount
    // initially it's [0, INFINITY, INFINITY, INFINITY, ...]
    for (int i = 0; i <= 74; ++i) {
        for (Pack pack : packs) {
            // if (i + pack.amount) can be achieved with smaller price, do it
            int newPrice = bestPrice[i] + pack.price;
            if (newPrice < bestPrice[i + pack.amount]) {
                bestPrice[i + pack.amount] = newPrice;
            }
        }
    }
