     if (IsTrue(var1, Operator.GreaterThanOrEqual,  var2))
        Console.WriteLine("var1 is greater than var2");
     else
        Console
            .WriteLine("Unfortunately var1 is not greater than or equal var2. Sorry about that.");
----------
         public static class Comparer
    {
        public static bool IsTrue<T, U>(T value1, Operator comparisonOperator, U value2)
                    where T : IComparable
                    where U : IComparable
        {
            switch (comparisonOperator)
            {
                case Operator.GreaterThan:
                    return value1.CompareTo(value2) > 0;
                case Operator.GreaterThanOrEqual:
                    return value1.CompareTo(value2) >= 0;
                case Operator.LessThan:
                    return value1.CompareTo(value2) < 0;
                case Operator.LessThanOrEqual:
                    return value1.CompareTo(value2) <= 0;
                case Operator.Equal:
                    return value1.CompareTo(value2) == 0;
                default:
                    return false;
            }
        }
        public enum Operator
        {
            GreaterThan = 1,
            GreaterThanOrEqual = 2,
            LessThan = 3,
            LessThanOrEqual = 4,
            Equal = 5
        }
    }
