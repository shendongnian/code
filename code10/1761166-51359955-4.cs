        public static List<long> ToLong(string numberString)
        {
            var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
                 .Select(m => m.Value.ToLowerInvariant())
                 .Where(v => numberTable.ContainsKey(v))
                 .Select(v => numberTable[v]);
            long acc = 0, total = 0L;
            List<long> sample = new List<long>();
            int prevIndex = 0, currIndex = 0;
            string currKey = "", prevKey = "";
            int i = 0;
            List<long> revList = numbers.ToList();
            revList.Reverse();
            foreach (var n in numbers)
            {
                numberString = numberString.Replace(" ", "");
                currKey = numberTable.FirstOrDefault(x => x.Value.ToString().ToLower() == n.ToString().ToLower()).Key;
                currIndex = numberString.ToLower().IndexOf(currKey.ToLower());
                bool isDiffNuber = !(prevIndex == 0 || currIndex - (prevIndex + prevKey.Length - 1) == 1);
                if (!isDiffNuber)
                {
                    if (n >= 1000)
                    {
                        total += (acc * n);
                        acc = 0;
                    }
                    else if (n >= 100)
                    {
                        acc *= n;
                    }
                    else
                        acc += n;
                }
                if (isDiffNuber || numbers.Last() == n)
                {
                    long val = total + acc;
                    sample.Add(val);
                    i++;
                    prevIndex = 0;
                    currIndex = 0;
                    prevKey = "";
                    currKey = "";
                    total = 0;
                    acc = 1;
                }
                prevIndex = currIndex;
                prevKey = currKey;
            }
            return sample;
        }
