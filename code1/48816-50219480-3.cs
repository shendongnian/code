    class Program
    {
        public static void Main(string[] args)
        {
            Permutation("abc");
        }
        static void Permutation(string rest, string prefix = "")
        {
            // End of recursion
            if (string.IsNullOrEmpty(rest)) Console.WriteLine(prefix);
            // Each letter has a chance to be permutated
            for (int i = 0; i < rest.Length; i++)
            {
                // Remove the first letter of string, append this letter to prefix
                // Pass the remaining string and appended prefix to the next recursion
                Permutation(rest.Remove(i, 1), prefix + rest[i]);
            }
        }
    }
