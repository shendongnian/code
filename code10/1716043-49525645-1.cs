    public class Program
    {
        public void Exercise1()
        {
            Console.Write("Enter a number between 1 to 10: ");
            var input = Console.ReadLine();
            var number = Convert.ToInt32(input);
            if (number >= 1 && number <= 10)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");
        }
    
        static void Main(string[] args)
        {
              var prog = new Program();
              prog.Exercise1(); 
        }
    }
