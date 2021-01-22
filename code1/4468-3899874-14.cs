    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book> {
            new Book{Isbn=1,Name="A",Weight=1},
            new Book{Isbn=2,Name="B",Weight=100},
            new Book{Isbn=3,Name="C",Weight=1000},
            new Book{Isbn=4,Name="D",Weight=10000},
            new Book{Isbn=5,Name="E",Weight=100000}};
            Book randomlySelectedBook = WeightedRandomization.Choose(books);
        }
    }
    public static class WeightedRandomization
    {
        public static T Choose<T>(List<T> list) where T : IWeighted
        {
            if (list.Count == 0)
            {
                return default(T);
            }
            int totalweight = list.Sum(c => c.Weight);
            Random rand = new Random();
            int choice = rand.Next(totalweight);
            int sum = 0;
            foreach (var obj in list)
            {
                for (int i = sum; i < obj.Weight + sum; i++)
                {
                    if (i >= choice)
                    {
                        return obj;
                    }
                }
                sum += obj.Weight;
            }
            return list.First();
        }
    }
    public interface IWeighted
    {
        int Weight { get; set; }
    }
    public class Book : IWeighted
    {
        public int Isbn { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
    }
