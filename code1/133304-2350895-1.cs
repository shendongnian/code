    double[] CoinValue = { 500, 200, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };
    
    uint[] result = new uint[CoinValue.Length];
    double ammount = 552.5;
    double remaining = ammount;
    
    for (int i = 0; i < CoinValue.Length; ++i) {
      result[i] = (uint) (remaining / CoinValue[i]);
        if (result[i] > 0)
          remaining = remaining % CoinValue[i];
    }
