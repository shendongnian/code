    int a;
    int b; //Declare these outside the loop.
    
    while(!(a > 0 && a < 10 && b > 2 && b <=15))
    {
       Console.WriteLine("Please Input a valid number for A.");
       a = Console.ReadLine();
       Console.WriteLine("Please Input a valid number for B.";
       b = Console.ReadLine();
    }
    
    int sum = a + b;
    
    Console.WriteLine($"The sum is {sum}.");
