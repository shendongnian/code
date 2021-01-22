     public static class Comparer
    {
        public static bool GetComparisonResult<T, U>(
            T value1, 
            ComparisonType compareType, 
            U value2)
                    where T : IComparable
                    where U : IComparable
        {
            switch (compareType)
            {
                case ComparisonType.GreaterThan:
                    return value1.CompareTo(value2) > 0;
                case ComparisonType.GreaterThanOrEqual:
                    return value1.CompareTo(value2) >= 0;
                case ComparisonType.LessThan:
                    return value1.CompareTo(value2) < 0;
                case ComparisonType.LessThanOrEqual:
                    return value1.CompareTo(value2) <= 0;
                case ComparisonType.Equal:
                    return value1.CompareTo(value2) == 0;
                default:
                    return false;
            }
        }
    
        public enum ComparisonType
        {
            GreaterThan = 1,
            GreaterThanOrEqual = 2,
            LessThan = 3,
            LessThanOrEqual = 4,
            Equal = 5
        }
    }
