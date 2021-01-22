	IVehicle parent;
	Door (IVehicle vehicle)
	{
		parent = vehicle;
	}
	public string Color
	{
		get
		{
			return parent.Color;
		}
	}
