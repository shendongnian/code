	class Program
	{
		public static void Main()
		{
			formPermut test = new formPermut();
			test.prnPermutWithSubsets(new object[] { 1, 2 });
			Console.WriteLine();
			test.prnPermutWithSubsets(new object[] { 1, 2, 3 });
			Console.WriteLine();
			test.prnPermutWithSubsets(new string[] { "one", "two", "three" });
			Console.WriteLine();
			return;
		}
	
		class formPermut
		{
			private void swapTwoNumber(ref object a, ref object b)
			{
				object temp = a;
				a = b;
				b = temp;
			}
			public void prnPermutWithSubsets(object[] list)
			{
				for (int i = 0; i < Math.Pow(2, list.Length); i++)
				{
					Stack<object> combination = new Stack<object>();
					for (int j = 0; j < list.Length; j++)
					{
						if ((i & (1 << (list.Length - j - 1))) != 0)
						{
							combination.Push(list[j]);
						}
					}
					this.prnPermut(combination.ToArray(), 0, combination.Count() - 1);
				}
			}
	
			public void prnPermut(object[] list, int k, int m)
			{
				int i;
				if (k == m)
				{
					for (i = 0; i <= m; i++)
						Console.Write("{0}", list[i]);
					Console.Write(" ");
				}
				else
					for (i = k; i <= m; i++)
					{
						swapTwoNumber(ref list[k], ref list[i]);
						prnPermut(list, k + 1, m);
						swapTwoNumber(ref list[k], ref list[i]);
					}
			}
		}
	}
