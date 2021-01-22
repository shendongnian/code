    static void Main(string[] args)
    {
		Timing timer = new Timing();
		
        int num1 = 100;
        int num2 = 200;
        Console.WriteLine("num1: " + num1);
        Console.WriteLine("num2: " + num2);
		
		//
		//----------------------------------
		timer.startTime();
        Swap<int>(ref num1, ref num2);
		timer.stopTime();
		Console.WriteLine("Time = " + timer.result());
		//----------------------------------
		///
		
        Console.WriteLine("num1: " + num1);
        Console.WriteLine("num2: " + num2);
        string str1 = "Sam";
        string str2 = "Tom";
        Console.WriteLine("String 1: " + str1);
        Console.WriteLine("String 2: " + str2);
        Swap<string>(ref str1, ref str2);
        Console.WriteLine("String 1: " + str1);
        Console.WriteLine("String 2: " + str2);
        Console.ReadKey();
    }
