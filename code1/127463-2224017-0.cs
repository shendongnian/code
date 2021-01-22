    static IEnumerable<int> PrimeNumbers(int maxValue)
    {
        if (maxValue > 1 && maxValue < int.MaxValue)
        {
            var integers = Enumerable.Range(2, maxValue);
            for (;;)
            {
                int item = integers.FirstOrDefault();
                if (item == 0)
                {
                    break;
                }
                yield return item;
                integers = integers.Where(x => x % item != 0);
            }
        }
    }
