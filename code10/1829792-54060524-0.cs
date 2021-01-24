    class Program
    {
        static void Main(string[] args)
        {
            List<KeyValueClass> myList = new List<KeyValueClass>
                {
                    new KeyValueClass {Age = 21, Name = "Carl"},
                    new KeyValueClass {Age = 23, Name = "Vladimir"},
                    new KeyValueClass {Age = 25, Name = "Bob"},
                    new KeyValueClass {Age = 21, Name = "Olivia"},
                    new KeyValueClass {Age = 21, Name = "Carl"},
                    new KeyValueClass {Age = 30, Name = "Jacob"},
                    new KeyValueClass {Age = 23, Name = "Vladimir"},
                };
            var myDistincList = myList.Distinct(new KeyValueEqualityComparer());
            foreach (var item in myDistincList) { Console.WriteLine("Age: {0}, Name:{1}", item.Age, item.Name); }
            Console.ReadKey();
        }
    }
    public class KeyValueClass 
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    class KeyValueEqualityComparer : IEqualityComparer<KeyValueClass>
    {
        public bool Equals(KeyValueClass x, KeyValueClass y)
        {
            if (x == null || y == null) return false;
            if (x.Age == y.Age && x.Name.Equals(y.Name)) return true;
            return false;
        }
        public int GetHashCode(KeyValueClass obj)
        {
            return (obj.Age + obj.Name).GetHashCode() + 387;
        }
    }
