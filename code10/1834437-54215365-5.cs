    class Program
    {
        static void Main(string[] args)
        {
            SayHi();
        }
        static void SayHi()
        {
            Console.WriteLine("Enter Your Name");
            var name=Console.ReadLine();
            Console.WriteLine("Enter Your Age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Hello "+"\t" + name + " "+"you are"+" " + age + " "+" Years old");
            Console.ReadLine();
        }
    }
    
           
}
