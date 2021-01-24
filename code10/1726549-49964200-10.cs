    public class myClass
    {
        public myClass([CallerFilePath] string fileName = "")
        {
            Console.WriteLine(fileName);
            Console.ReadKey();
        }
    }
