	[Flags]
	enum Test
	{
		F1 = 1,
		F2 = 2,
		F3 = 4
	}
	class Program
	{
		static void Main(string[] args)
		{
			int v = (int) (Test.F1 | Test.F2 | Test.F3); // count bits set in this (32-bit value)
			int c = 0; // store the total here
			int[] S = {1, 2, 4, 8, 16}; // Magic Binary Numbers
			int[] B = {0x55555555, 0x33333333, 0x0F0F0F0F, 0x00FF00FF, 0x0000FFFF};
			c = v - ((v >> 1) & B[0]);
			c = ((c >> S[1]) & B[1]) + (c & B[1]);
			c = ((c >> S[2]) + c) & B[2];
			c = ((c >> S[3]) + c) & B[3];
			c = ((c >> S[4]) + c) & B[4];
			Console.WriteLine(c);
			Console.Read();
		}
	}
