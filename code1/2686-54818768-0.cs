       public static TEnum ToEnum<TEnum>(this int val) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                return default(TEnum);
            }
            if (Enum.IsDefined(typeof(TEnum), val))
            {//if a straightforward single value, return that
                return (TEnum)Enum.ToObject(typeof(TEnum), val);
            }
            var candidates = Enum
                .GetValues(typeof(TEnum))
                .Cast<int>()
                .ToList();
            
            var isBitwise = candidates
                .Select((n, i) => {
                    if (i < 2) return n == 0 || n == 1;
                    return n / 2 == candidates[i - 1];
                })
                .All(y => y);
            var maxPossible = candidates.Sum();
            if (
                Enum.TryParse(val.ToString(), out TEnum asEnum)
                && (val <= maxPossible || !isBitwise)
            ){//if it can be parsed as a bitwise enum with multiple flags,
              //or is not bitwise, return the result of TryParse
                return asEnum;
            }
            //If the value is higher than all possible combinations,
            //remove the high imaginary values not accounted for in the enum
            var excess = Enumerable
                .Range(0, 32)
                .Select(n => (int)Math.Pow(2, n))
                .Where(n => n <= val && n > 0 && !candidates.Contains(n))
                .Sum();
            return Enum.TryParse((val - excess).ToString(), out asEnum) ? asEnum : default(TEnum);
        }
