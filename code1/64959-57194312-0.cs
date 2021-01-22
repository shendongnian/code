	internal const int BLOCK_SIZE = 256;
	public static void Fill<T>(this T[] array, T value)
	{
		if (array.Length < 2 * BLOCK_SIZE)
		{
			for (int i = 0; i < array.Length; i++) array[i] = value;
		}
		else
		{
			int fullBlocks = array.Length / BLOCK_SIZE;
			// Initialize first block
			for (int j = 0; j < BLOCK_SIZE; j++) array[j] = value;
			// Copy successive full blocks
			for (int blk = 1; blk < fullBlocks; blk++)
			{
				Array.Copy(array, 0, array, blk * BLOCK_SIZE, BLOCK_SIZE);
			}
			for (int rem = fullBlocks * BLOCK_SIZE; rem < array.Length; rem++)
			{
				array[rem] = value;
			}
		}
	}
