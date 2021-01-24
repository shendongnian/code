	public class PoundsToKilos
	{
		public static void Main()
		{
			double pounds = 0.0;
			Console.Write("How many pounds?  ");
			if (double.TryParse(Console.ReadLine(), out pounds))
			{
				//`pounds` has been assigned a value
				double kilograms = pounds * 0.453592;
				Console.WriteLine("{0} pounds is equal to {1} kilograms", pounds, kilograms);
			}
			else
			{
				//`pounds` has NOT been assigned a value
				Console.WriteLine("You didn't enter a valid number.");
			}
			Console.WriteLine("Press enter to exit.");
			Console.ReadLine();
		}
	}
