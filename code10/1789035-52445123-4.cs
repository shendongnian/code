        public class Data : IComparable<Data>
        {
            public DateTime Date { get; private set; }
            public int Income { get; private set; }
            public Data(DateTime date, int income)
            {
                Date = date;
                Income = income;
            }
            public int CompareTo(Data other)
            {
                return Income.CompareTo(other.Income);
            }
        }
        class Program
        {
            var data = GetSampleData();
            var result = data.GroupBy(x => x.Date.Hour)
           .Select(z => new Data (z.First().Date, z.Sum(a => a.Income)))
           .Max();
            Console.WriteLine($"Hour: {result.Date.Hour}, Income:{result.Income}");
        }
