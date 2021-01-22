    class Program
    {
        static void Main(string[] args)
        {
            string[] x = new string[20];
            for (int i = 0; i < x.Length; i++)
                x[i] = (i+1).ToString();
            string[] y = (string[])MyArrayFunctions.RemoveAt(x, 3);
            for (int i = 0; i < y.Length; i++)
                Console.WriteLine(y[i]);
        }
    }
