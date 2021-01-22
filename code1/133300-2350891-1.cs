        decimal value = 10023.23M;
        decimal[] CoinValue = { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.5M, 0.2M, 0.1M, 0.05M, 0.02M, 0.01M };
        int[] counts = new int[CoinValue.Length];
        for (int i = 0; i < CoinValue.Length; i++) {
            decimal v = CoinValue[i];
            while (value >= v) {
                counts[i]++;
                value -= v;
            }
        }
        for (int i = 0; i < CoinValue.Length; i++) {
            if (counts[i] > 0) {
                Console.WriteLine(CoinValue[i] + "\t" + counts[i]);
            }
        }
        Console.WriteLine("Untendered: " + value);
