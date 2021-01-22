    class Program
    {
        public static void Main(string[] args)
        {
            Permutation("abc");
        }
        static void Permutation(string rest, string prefix = "")
        {
            if (string.IsNullOrEmpty(rest)) Console.WriteLine(prefix);
            // Each letter has a chance to be permutated
            for (int i = 0; i < rest.Length; i++)
            {                
                Permutation(rest.Remove(i, 1), prefix + rest[i]);
            }
        }
    }
