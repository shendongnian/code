	public bool Equals(T x, T y)
	{
		if (x is Accessory && y is Accessory)
		{
			var ax = x as Accessory;
			var ay = y as Accessory;
			return ax.Id == ay.Id;
		}
		return false;
	}
