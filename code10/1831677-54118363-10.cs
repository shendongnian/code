	public static class Vector3Extensions
	{
		public static Vector3[,] ToVector3(this (float X, float Y)[,] value)
		{
			int columnCount = value.GetUpperBound(0);
            int rowCount = value.GetLength(0);
			
			Vector3[,] result = new Vector3[rowCount, columnCount];
			for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
					(float X, float Y) tuple = ((float X, float Y))value.GetValue(i, j);
                    result[i, j] = tuple.ToVector3();
                }
            }
			
			return result;
		}
		
		public static Vector3 ToVector3(this (float X, float Y) value)
		{
			return new Vector3(value.X, value.Y);
		}
    }
