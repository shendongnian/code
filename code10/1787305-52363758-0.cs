    private async Task<List<Currency>> Test2Async()
    {
        using (var dc = new LandmarkEntities())
        {
            return await dc
                .get_currencies()
                .Select(x => new Currency
                {
                    ExchangeRate = x.exchange_rate,
                    Mnemonic = x.mnemonic,
                })
                .ToListAsync();
        }
    }
