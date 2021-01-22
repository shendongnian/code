	public static Tuple<double, double, double> ColorToHSV(Color color)
	{
		int max = Math.Max(color.R, Math.Max(color.G, color.B));
		int min = Math.Min(color.R, Math.Min(color.G, color.B));
		double hue = color.GetHue();
		double saturation = (max == 0) ? 0 : 1d - (1d * min / max);
		double value = max / 255d;
		return Tuple.Create<double, double, double>(hue, saturation, value);
	}
