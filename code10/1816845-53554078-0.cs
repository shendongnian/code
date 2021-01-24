    public static double MaxIndex(double[] array)
	{
		var max = double.MinValue;
		int maxInd = -1;
		for (int i = 0; i < array.Length; i++)
		{
			if (max < array[i])
			{
				max = array[i];
				maxInd = i;
			}
		}
		return maxInd;
	}
