	Console.WriteLine("Input a number");
    int num = Convert.ToInt32(Console.ReadLine());
	int sum = 0;
    
    for (int i = 4; i > 0; i--)
    {                
        sum += num % 10 * i;
        num /= 10;
    }
	
	Console.WriteLine(sum);
