    class Program
    {
        static void Main(string[] args)
        {
            var obj = new CSharpFunction("Test");
            string output = obj.TransformText();
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
