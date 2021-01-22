	using System.Convert;
	public static Color oddColorFunction(int value)
	{
		Color colors = new Color[] { Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Red };
		int min = 0;
		int max = 400;
		decimal range = max / colors.Length;
		
		Color leftColor = ToInt32(Decimal.Floor(value / range));
		Color rightColor = ToInt32(Decimal.Ceiling(value / range));
		
		return mixColors(colors[leftColor], colors[rightColor], ToInt32(Decimal.Round(value % range * 100)));
	}
	
	public static mixColors(Color colorA, Color colorB, int percentage)
	{
		//combine colors here based on percentage
		//I'm to lazy to code this :P
	}
