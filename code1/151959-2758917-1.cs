    class Program
    {
        static void Main()
        {
            List<ReservationPrice> prices = new List<ReservationPrice>();
            prices.Add(new ReservationPrice { NumberOfDays = 1, Price = 1000 });
            prices.Add(new ReservationPrice { NumberOfDays = 2, Price = 1200 });
            prices.Add(new ReservationPrice { NumberOfDays = 3, Price = 2500 });
            prices.Add(new ReservationPrice { NumberOfDays = 4, Price = 3100 });
            prices.Add(new ReservationPrice { NumberOfDays = 7, Price = 4000 });
            DaysMinSum.Precompute(prices);
            Console.WriteLine(DaysMinSum.GetAnswer(5));
            Console.WriteLine(DaysMinSum.GetAnswer(4));
            Console.WriteLine(DaysMinSum.GetAnswer(7));
            Console.WriteLine(DaysMinSum.GetAnswer(6));
            Console.WriteLine(DaysMinSum.GetAnswer(100));
            Console.WriteLine(DaysMinSum.GetAnswer(3));
        }
    }
    static class DaysMinSum
    {
        private static Dictionary<int, int> S = new Dictionary<int, int>();
        public static int GetAnswer(int numDays)
        {
            if (S.ContainsKey(numDays))
            {
                return S[numDays];
            }
            else
            {
                return -1;
            }
        }
        public static void Precompute(List<ReservationPrice> prices)
        {
            S.Clear();
            int maxDays = 0;
            for (int i = 0; i < prices.Count; ++i)
            {
                maxDays += prices[i].NumberOfDays;
            }
            for (int i = 0; i <= maxDays; ++i)
            {
                S.Add(i, 1 << 30);
            }
            S[0] = 0;
            for (int i = 0; i < prices.Count; ++i)
            {
                for (int j = maxDays; j >= prices[i].NumberOfDays; --j)
                {
                    S[j] = Math.Min(S[j], S[j - prices[i].NumberOfDays] + prices[i].Price);
                }
            }
        }
    }
    class ReservationPrice
    {
        public int NumberOfDays { get; set; }
        public int Price { get; set; }
    }
    
