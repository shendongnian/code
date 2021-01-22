    class Program
    {
        static void Main()
        {
            // Outputs "True"
            Debug.WriteLine(string.IsInterned(string.Empty) != null);
        }
    }
    class Program
    {
        static void Main()
        {
            // Outputs "True"
            Debug.WriteLine(string.IsInterned("") != null);
        }
    }
