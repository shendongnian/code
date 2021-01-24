    class Program
    {
        static void Main(string[] args)
        {
            string name = "Rooazoooooooooor";
            string resultName = string.Empty;
            foreach (var currentChar in name)
            {
                if (currentChar != 'o')
                    resultName += currentChar;
            }
            Console.Write(resultName);
            Console.ReadKey();
        }
    }
`
