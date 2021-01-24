    private static IEnumerable<StockData> ReadStockData(string path)
    {
        const int ExpectedSize = 15000;
        var stockData = new List<StockData>(ExpectedSize);
        foreach (string line in File.ReadLines(path)) {
            string[] parts = line.Split(',');
            if (parts.Length == 7) { // Exclude empty lines etc.
                var data = new StockData {
                    Symbol = parts[0],
                    Date = DateTime.Parse(parts[1]),
                    Open = Decimal.Parse(parts[2]),
                    High = Decimal.Parse(parts[3]),
                    Close = Decimal.Parse(parts[4]),
                    Low = Decimal.Parse(parts[5]),
                    Volume = Int32.Parse(parts[6])
                };
                stockData.Add(data);
            }
        }
        return stockData;
    }
