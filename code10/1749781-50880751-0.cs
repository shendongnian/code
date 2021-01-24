    using System;
    using System.Linq;
    namespace Arrays
    {
	class SplitArray
	{
		public static void Main(string[] args)
		{
			int[] myArray = GetNumbersFromConsole();
			int[] smallNumbers = new int[myArray.Length];
			int[] bigNumbers = new int[myArray.Length];
			int bigIndex = 0;
			int littleIndex = 0;
			for (int i = 0; i < myArray.Length; i++)
			{
				if(myArray[i] > 100)
				{
					bigNumbers[bigIndex++] = myArray[i];
				}
				else if(myArray[i] < 100)
				{
					smallNumbers[littleIndex++] = myArray[i];
				}
			}
			Console.Write("Big: ");
			Console.Write($"{bigNumbers[0]} ");
			for (int i = 1; i < bigIndex; i++)
			{
				Console.Write(bigNumbers[i]);
				if (i != bigIndex - 1)
				{
					Console.Write(" ");
				}
			}
			
			Console.WriteLine();
			Console.Write("Little: ");
			Console.Write($"{smallNumbers[0]} ");
			for (int i = 1; i < littleIndex; i++)
			{
				Console.Write($"{smallNumbers[i]}");
				if (i != littleIndex - 1)
				{
					Console.Write(" ");
				}
			}
			Console.ReadLine();
		}
		static int[] GetNumbersFromConsole()
		{
			int count = int.Parse(Console.ReadLine());
			int[] result = new int[count];
			for (int i = 0; i < count; ++i)
			{
				result[i] = int.Parse(Console.ReadLine());
			}
			return result;
		}
	}
    }
