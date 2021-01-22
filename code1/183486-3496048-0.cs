    // bestPrice is array of best prices for each amount
    // initially it's [0, INFINITY, INFINITY, INFINITY, ...]
    for (int i = 0; i <= 74; ++i) {
        for (Pack pack : packs) {
            int new = bestPrice[i] + pack.price;
            if (new < bestPrice[i + pack.amount]) {
                bestPrice[i + pack.amount] = new;
            }
        }
    }
