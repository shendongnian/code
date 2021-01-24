    static int? CompNumbers(double x, double y) //int? is nothing more than nullable int
        {
            if (x == y)
            {
                return 0;
            }
            else if (x > y)
            {
                return 1;
            }
            else if (y > x)
            {
                return -1;
            }
            return null; //this is the return value you have give !!
        }
        static void Main(string[] args)
        {
            double a = Convert.ToDouble(Console.ReadLine());//taking input from user 
            double b = Convert.ToDouble(Console.ReadLine());//taking input from user
            int? result = CompNumbers(a, b);//assigning result to the return value of CompNumbers   and  int? is nothing more than nullable int
            if (result == 0)
            {
                Console.WriteLine("The Method returned 0");
            }
            else if (result == 1)
            {
                Console.WriteLine("The Method returned 1");
            }
            else if(result == -1)
            {
                Console.WriteLine("The Method returned -1");
            }
            Console.ReadKey();
        }
