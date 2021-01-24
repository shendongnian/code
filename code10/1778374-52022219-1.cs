	public bool Equals(T x, T y)
	{
		if (x is Accessory ax && y is Accessory ay)
		{
			return ax.Id == ay.Id;
		}
		return false;
	}
