        static List<int> GetPrimeNumbers(int maxNumber)
        {
            // seed the master list with 2
            var list = new List<int>() {2};
            // start at 3 and build the complete list
            var next = 3;
            while (next <= maxNumber)
            { 
                // since even numbers > 2 are never prime, ignore evens 
                if (next % 2 != 0) 
                    list.Add(next);
                next++;
            }
            // create copy of list to avoid reindexing
            var primes = new List<int>(list);
            // index starts at 1 since the 2's were never removed
            for (int i = 1; i < list.Count; i++)
            {
                var multiplier = list[i];
                // FindAll Lambda removes duplicate processing
                list.FindAll(a => primes.Contains(a) && a > multiplier)
                    .ForEach(a => primes.Remove(a * multiplier));
            }
            return primes;
        }
