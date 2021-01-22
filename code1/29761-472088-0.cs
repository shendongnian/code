    public static List<int> getNumbers(int n)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            List<int> obtainedNumbers = new List<int>(); 
            do
            {
                obtainedNumbers.Add(random.Next(1, 9));
            }
            while (n - obtainedNumbers.Sum() > 0);
            return obtainedNumbers;
        }
