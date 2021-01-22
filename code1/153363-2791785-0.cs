    namespace Units
    {
        class Weight
        {
            public enum WeightType
            {
                kg,
                lb
            }
            const double kgTolbs = 2.20462262;
            public static double Convert(double value, WeightType fromUnits, WeightType toUnits)
            {
                //Code here to convert units
            }
        }
    }
