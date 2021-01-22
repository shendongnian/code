    using System.Collections.Generic;
    using System.Linq;
    
    public static class HashCodeCalculator
    {
        public static int CalculateHashCode(params object[] args)
        {
            return args.CalculateHashCode();
        }
        public static int CalculateHashCode(this IEnumerable<object> args)
        {
            if (args == null)
                return new object().GetHashCode();
            unchecked
            {
                return args.Aggregate(0, (current, next) => (current*419) ^ (next ?? new object()).GetHashCode());
            }
        }
    }
