    private static readonly IDictionary<Keys, int> NumericKeys = 
        new Dictionary<Keys, int> {
            { Keys.D0, 0 },
            { Keys.D1, 1 },
            { Keys.D2, 2 },
            { Keys.D3, 3 },
            { Keys.D4, 4 },
            { Keys.D5, 5 },
            { Keys.D6, 6 },
            { Keys.D7, 7 },
            { Keys.D8, 8 },
            { Keys.D9, 9 },
            { Keys.NumPad0, 0 },
            { Keys.NumPad1, 1 },
            { Keys.NumPad2, 2 },
            { Keys.NumPad3, 3 },
            { Keys.NumPad4, 4 },
            { Keys.NumPad5, 5 },
            { Keys.NumPad6, 6 },
            { Keys.NumPad7, 7 },
            { Keys.NumPad8, 8 },
            { Keys.NumPad9, 9 }
       };
    private int? GetKeyNumericValue(KeyEventArgs e) {
        if (NumericKeys.ContainsKey(e.KeyCode)) return NumericKeys[e.KeyCode];
        else return null;
    }
