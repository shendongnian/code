    class Program
    {
        static void Main(string[] args)
        { 
           Console.Write("Enter the value:");
           int m = int.Parse(Console.ReadLine());
           if (m == 0)
               return;
            for(int i=1;i<=10;i++)
                Console.WriteLine("{0} * {1} ={2}",m,i,m*i);
            Console.ReadLine();
        }
    }
