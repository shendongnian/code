    class Program
    {
        static void Main(string[] args)
        {
            // See I added an item at the end here to show when Equals is called
            List<string> lst = new List<string> { "abcXdef", "abcXdef", "abcede", "aYcde", "X" };
            List<string> num = new List<string> { "X", "Y", "Z" };
            var fin = lst.Intersect(num, new MiNumeroEqualityComparer()).ToList();
            Console.ReadLine();
        }
    }
    public class MiNumeroEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            Console.WriteLine("Equals called for {0} and {1}.", x, y);
            return x.Contains(y);
        }
        public int GetHashCode(string obj)
        {
            Console.WriteLine("GetHashCode alled for {0}.", obj);
            return obj.GetHashCode();
        }
    }
