    List<int> MergeSorting(List<int> a, List<int> b)
        {
            int apos = 0;
            int bpos = 0;
            List<int> result = new List<int>();
            while (apos < a.Count && bpos < b.Count)
            {
                int avalue = int.MaxValue;
                int bvalue = int.MaxValue;
                if (apos < a.Count)
                    avalue = a[apos];
                if (bpos < b.Count)
                    bvalue = b[bpos];
                if (avalue < bvalue)
                {
                    result.Add(avalue);
                    apos++;
                }
                else
                {
                    result.Add(bvalue);
                    bpos++;
                }
            }
            return result;
        }
