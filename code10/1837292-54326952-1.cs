	public static Color TemperatureRange(double BlueToRed)
	{
		double r, g, b;
		// blue to cyan
		if (BlueToRed < -0.5)
		{
			r = 0;
			g = 2 + BlueToRed * 2;
			b = 1;
		}
		// cyan to green
		else if (BlueToRed < 0)
		{
			r = 0;
			g = 1;
			b = -BlueToRed * 2;
		}
		// green to yellow
		else if (BlueToRed < 0.5)
		{
			r = BlueToRed * 2;
			g = 1;
			b = 0;
		}
		// yellow to red
		else
		{
			r = 1;
			g = 2 - BlueToRed * 2;
			b = 0;
		}
		return Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
	}
