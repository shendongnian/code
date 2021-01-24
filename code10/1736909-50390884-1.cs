    var lbo1 = new LegacyBusinessObject
    {
        SomeBusinessValue1 = new Dictionary<string, string> { { "A1", "A2" }, { "B1", "B2" } },
        SomeBusinessValue2 = new Dictionary<string, long> { { "C1", 1 }, { "D1", 2 } },
        SomeBusinessValue3 = new Dictionary<string, decimal> { { "E1", 3 }, { "F1", 4 } },
    };
    var lbo2 = new LegacyBusinessObject
    {
        SomeBusinessValue1 = new Dictionary<string, string> { { "G1", "G2" }, { "H1", "H2" } },
        SomeBusinessValue2 = new Dictionary<string, long> { { "I1", 5 }, { "J1", 6 } },
        SomeBusinessValue3 = new Dictionary<string, decimal> { { "K1", 7 }, { "L1", 8 } },
    };
    var result = Merge(new Dictionary<string, LegacyBusinessObject> { { "X", lbo1 }, { "Y", lbo2 } });
