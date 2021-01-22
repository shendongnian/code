    public class Example
    {
        public static Book GetBook()
        {
            var books = new List<Book> {
                new Book{Isbn=1,Name="A",Weight=1},
                new Book{Isbn=2,Name="B",Weight=100},
                new Book{Isbn=3,Name="C",Weight=1000},
                new Book{Isbn=4,Name="D",Weight=10000},
                new Book{Isbn=5,Name="E",Weight=100000}};
            return WeightedRandomization.Choose(books, new Random()) as Book;
        }
    }
    public class WeightedRandomization
    {
        public static IWeighted Choose<T>(List<T> list, Random rand) where T : IWeighted
        {
            int totalweight = list.Sum(c => c.Weight);
            int choice = rand.Next(totalweight);
            int sum = 0;
            foreach (IWeighted obj in list)
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
            return null;
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
