        public static ulong Sum(this IEnumerable<ulong> source)
        {
            var sum = 0UL;
            foreach (var number in source)
            {
                sum += number;
            }
            return sum;
        }
        public static ulong? Sum(this IEnumerable<ulong?> source)
        {
            var sum = 0UL;
            foreach (var nullable in source)
            {
                if (nullable.HasValue)
                {
                    sum += nullable.GetValueOrDefault();
                }                
            }
            return sum;
        }
