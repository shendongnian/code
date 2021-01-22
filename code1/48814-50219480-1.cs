    class Program
    {
        static void Main(string[] args)
        {
            Permutation("abc");
        }
        static void Permutation(string rest, string prefix = "")
        {
            if (string.IsNullOrEmpty(rest)) Console.WriteLine(prefix);
            for (int i = 0; i < rest.Length; i++)
            {
                Permutation(rest.Remove(i, 1), prefix + rest[i]);
            }
        }
    }
