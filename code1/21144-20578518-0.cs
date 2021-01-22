	public void GetIndexOf(Transform transform, out int outX, out int outY)
	{
		outX = -1;
		outY = -1;
		for (int x = 0; x < Columns.Length; x++)
		{
			var column = Columns[x];
			for (int y = 0; y < column.Transforms.Length; y++)
			{
				if(column.Transforms[y] == transform)
				{
					outX = x;
					outY = y;
					return;
				}
			}
		}
	}
