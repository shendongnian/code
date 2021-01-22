    class Program
    {
        static void Main(string[] args)
        {
            Permutation("abcd");
        }
        static void Permutation(string input)
        {
            // Call helper method
            Permutation(string.Empty, input);
        }
        // Helper method
        static void Permutation(string prefix, string rest)
        {
            if (string.IsNullOrEmpty(rest)) Console.WriteLine(prefix);
            for (int i = 0; i < rest.Length; i++)
            {
                Permutation(prefix + rest[i], rest.Remove(i, 1));
            }
        }
    }
