    static void Main(string[] args)
    {                    
        Console.WriteLine("Type Exit to stop the program... \nEnter number");
		List<double> doubleList = new List<double>();
		string input = Console.ReadLine();
		double d;
		while(!input.Equals("Exit"))
		{
			if(String.IsNullOrEmpty(input) || !Double.TryParse(input,out d))
			{
				break;
			}
			doubleList(d);
			input = Console.ReadLine();
		}
        double num1 = Convert.ToInt32();
        average(num1, num2, num3);         
        Console.ReadKey();           
    }
    static void average(List<double> doubleData)
    {
		double total = 0;
		foreach (double number in doubleData)
		{
			total += number;
		}
		Console.WriteLine("Average = " + total/doubleData.Count);                                
    }
