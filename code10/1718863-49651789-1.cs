    class Program
    {
        static void Main(string[] args)
        {
            Manager objManager = new  Manager();
            Console.WriteLine(objManager.X);
            
            objManager.Modify();
            Console.WriteLine(objManager.X);
            Console.ReadLine();
        }
    }
