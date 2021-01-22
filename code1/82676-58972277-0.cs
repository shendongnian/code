using System;
using static System.Console;
namespace IntToBits
{
	class Program
	{
		static void Main()
		{
			while (true)
			{
				string s = Console.ReadLine();
				Clear();
				uint i;
				bool b = UInt32.TryParse(s, out i);
				if (b) IntPrinter(i);
			}
		}
		static void IntPrinter(uint i)
		{
			int[] iarr = new int [32];
			Write("[");
			for (int j = 0; j < 32; j++)
			{
				uint tmp = i & (uint)Math.Pow(2, j);
				
				iarr[j] = (int)(tmp >> j);
			}
			for (int j = 32; j > 0; j--)
			{
				if(j%8==0 && j != 32)Write("|");
				if(j%4==0 && j%8 !=0) Write("'");
				Write(iarr[j-1]);
			}
			WriteLine("]");
		}
	}
}
