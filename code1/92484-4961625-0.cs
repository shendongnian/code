    class Program
    {
        long fun(long a)
        {
            if (a <= 1)
            {
                return 1;}
            else
            {
                long c = a * fun(a - 1);
                return c;
            }}
        static void Main(string[] args)
        {
         
            Console.WriteLine("enter the number");
             long num = Convert.ToInt64(Console.ReadLine());
     Console.WriteLine(new Program().fun(num));
            Console.ReadLine();
        }
    }
}
