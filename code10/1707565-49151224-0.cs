	static void Main(string[] args)
	{
		MainMenu();
	}
	
	static void MainMenu()
	{
		int sel = -1;
		while (sel != 2)
		{
			Console.WriteLine("Calculator");
			Console.WriteLine("********************");
			Console.WriteLine("1- Calculator");
			Console.WriteLine("2- Exit Calculator");
			Console.Write("Please enter your option here:  ");
	
			sel = int.Parse(Console.ReadLine());
	
			if (sel == 1)
			{
				SecondMenu();
			}
			else if (sel != 2)
			{
				Console.WriteLine("Sorry that is not correct format! Please restart!"); //Catch                    
			}
		}
	}
	
	static void SecondMenu()
	{
		var options = new Dictionary<char, Func<double, double, double>>()
		{
			{ 'a', (x, y) => x + y },
			{ 's', (x, y) => x - y },
			{ 'd', (x, y) => x / y },
		};
		
		while (true)
		{
			Console.WriteLine("");
			Console.WriteLine("********************");
			Console.WriteLine("A. Addition");
			Console.WriteLine("S. Substraction");
			Console.WriteLine("D. Division");
			Console.WriteLine("********************");
			Console.Write("Please enter your option here:   ");
	
			char sel = Convert.ToChar(Console.ReadLine());
			if (options.ContainsKey(sel))
			{
				Calculate(options[sel]);
				break;
			}
		}
	}
	
	static void Calculate(Func<double, double, double> operation)
	{
		Console.WriteLine("Please enter the first number: ");
		double num1 = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Please enter the second number: ");
		double num2 = Convert.ToDouble(Console.ReadLine());
		double res = operation(num1, num2);
		Console.WriteLine("RESULT:  " + res);
		Console.WriteLine("");
		Console.ReadLine();
	}
