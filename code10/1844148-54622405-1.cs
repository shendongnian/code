	public enum MarkType
	{
		Free = 0,
		Nought = 1,
		Cross = 2
	}
	private const int size = 5;
	private readonly MarkType[] mResults = new MarkType[size * size];
	
	public MarkType CheckWin()
	{
		for (var x = 0; x < size; x++)
		{
			for (var y = 0; y < size; y++)
			{
				var offset = y * size + x;
				var mark = mResults[offset];
				if (mark == MarkType.Free)
				{
					// We don't do the checks when we are on a free mark
					continue;
				}
				if (x <= size - 3 && mark == mResults[offset + 1] && mark == mResults[offset + 2])
				{
					// Horizontal match at (x,y)..(x+2,y)
					return mark;
				}
				if (y <= size - 3 && mark == mResults[offset + size] && mark == mResults[offset + size * 2])
				{
					// Vertical match at (x,y)..(x,y+2)
					return mark;
				}
				if (x <= size - 3 && y <= size - 3 && mark == mResults[offset + (size + 1)] && mark == mResults[offset + (size + 1) * 2])
				{
					// Diagonal match at (x,y)..(x+2,y+2)
					return mark;
				}
				if (x <= size - 3 && y >= 2 && mark == mResults[offset - (size - 1)] && mark == mResults[offset - (size - 1) * 2])
				{
					// Diagonal match at (x,y)..(x+2,y-2)
					return mark;
				}
			}
		}
		return MarkType.Free;
	}
