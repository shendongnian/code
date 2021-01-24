	public static void Main()
	{				
		int[] a1 = { 42, 3, 9, 42, 42, 0, 42, 9, 42, 42, 17, 8, 2222, 4, 9, 0, 1 };
		int[] a2 = { 42, 2222, 9 };
		
		for(int i = 0; i < a1.Length; i++)
		{
			if(a2.Contains(a1[i]))
			{
                //notice i-- here because iterating array shifted to left
				ShiftToLeft(a1, i--+1);			
			}
		}
		
		Console.WriteLine(string.Join(",", a1));
	}
	
	private static void ShiftToLeft(int[] array, int fromIndex)
	{
		Array.Copy(array, fromIndex, array, fromIndex-1, array.Length - fromIndex);
		array[array.Length-1] = 0;
	}
