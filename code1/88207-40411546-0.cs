        /// <summary>
        /// Round list of numbers using the Largest Remainder Method. Sum of Numbers should equal 100.
        /// </summary>
        /// <param name="Numbers">List of decimals numbers to round</param>
        /// <returns>Rounded list of integers</returns>
        public static List<int> RoundNumberList(List<decimal> Numbers)
        {
            int sum = 0;
            var rounded = new Dictionary<int, decimal>();
            for (int i = 0; i < Numbers.Count; i++)
            {
                rounded.Add(i, Numbers[i]);
                sum += (int)Numbers[i];
            }
            if (sum > 100)
                throw new Exception("The sum of all numbers is > 100.");
            if (100 - sum > Numbers.Count)
                throw new Exception("The sum of all numbers is too low for rounding: " + sum.ToString());
            if (sum < 100)
            {
                // Sort descending by the decimal portion of the number
                rounded = rounded.OrderByDescending(n => n.Value-(int)n.Value).ToDictionary(x => x.Key, x => x.Value);
                int i = 0;  
                int diff = 100 - sum;
                foreach (var key in rounded.Keys.ToList())
                {
                    rounded[key]++;
                    i++;
                    if (i >= diff) break;
                }
                // Put back in original order and return just integer portion
                return rounded.OrderBy(n => n.Key).Select(n => (int)n.Value).ToList();
            }
            else
            {
                // Return just integer portion
                return rounded.Select(n => (int)n.Value).ToList();
            }
        }
