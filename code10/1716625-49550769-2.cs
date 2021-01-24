	public class Program
	{
		public static int[] DistinctFirst(int[] arr)
		{
			var lbound = 0;
			var ubound = arr.GetUpperBound(0);
			var i = ubound;
			while ( i>lbound )
			{
				var k = i;
				for (int j=i-1; j>=lbound; j--)
				{
					if (arr[j] == arr[i])
					{
						Swap(ref arr[j], ref arr[i-1]);
						i--;
					}
				}
				if (k == i)
				{
					Swap(ref arr[i], ref arr[lbound]);
					lbound++;
				}
				else
				{
					i--;
				}
			}
			return arr;
		}
		
		public static void Swap(ref int a, ref int b)
		{
			int c = a;
			a = b;
			b = c;
		}
		
		public static void Main() 
		{
			int[] arr = {1, 1, 6, 5, 4, 3, 4, 6, 1, 7, 2, 1, 4, 9};
			int[] result = DistinctFirst(arr);
			
			foreach (var i in result)
			{
				Console.WriteLine(i);
			}
		}
	}
