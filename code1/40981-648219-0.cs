    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SimpleConvert.To<double>("5.6"));
            Console.WriteLine(SimpleConvert.To<decimal>("42"));
        }
    }
    public static class SimpleConvert
    {
        public static T To<T>(string value)
        {
            Type target = typeof (T);
            if (dicConversions.ContainsKey(target))
                return (T) dicConversions[target](value);
    
            throw new NotSupportedException("The specified type is not supported");
        }
    
        private static readonly Dictionary<Type, Func<string, object>> dicConversions = new Dictionary <Type, Func<string, object>> {
            { typeof (Decimal), v => Convert.ToDecimal(v) },
            { typeof (double), v => Convert.ToDouble( v) } };
    }
