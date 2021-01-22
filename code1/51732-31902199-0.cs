    static void Main(string[] args)
            {
                Console.WriteLine("Prof.Owais ahmed");
                Console.WriteLine("Swapping two variables");
    
                Console.WriteLine("Enter your first number ");
                int x = Convert.ToInt32(Console.ReadLine());
    
                Console.WriteLine("Enter your first number ");
                int y = Convert.ToInt32(Console.ReadLine());
    
                Console.WriteLine("your vlaue of x is="+x+"\nyour value of y is="+y);
    
                int z = x;
                x = y;
                y = z;
    
                Console.WriteLine("after Swapping value of x is="+x+"/nyour value of y is="+y);
                Console.ReadLine();
        enter code here
            }
