        public static bool IsConsecutiveFactored(int number)
        {
            var ints = Factor(number);
            return (from i in ints join s in ints on i equals s + 1 
                    where i > 1 && s > 1
                    select i).Count() > 0;
        }
        private static List<int> Factor(int number)
        {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for (int factor = 1; factor <= max; ++factor)
            { //test from 1 to the square root, or the int below it, inclusive.
                if (number % factor == 0)
                {
                    factors.Add(factor);
                    if (factor != max)
                    { // Don't add the square root twice!  Thanks Jon
                        factors.Add(number / factor);
                    }
                }
            }
            return factors;
        }
