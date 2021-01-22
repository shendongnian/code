	private static readonly Regex rxScientific = new Regex(@"^(?<sign>-?)(?<head>\d+)(\.(?<tail>\d*?)0*)?E(?<exponent>[+\-]\d+)$", RegexOptions.IgnoreCase|RegexOptions.ExplicitCapture|RegexOptions.CultureInvariant);
	public static string ToFloatingPointString(double value) {
		return ToFloatingPointString(value, NumberFormatInfo.CurrentInfo);
	}
	public static string ToFloatingPointString(double value, NumberFormatInfo formatInfo) {
		string result = value.ToString("r", NumberFormatInfo.InvariantInfo);
		Match match = rxScientific.Match(result);
		if (match.Success) {
			Debug.WriteLine("Found scientific format: {0} => [{1}] [{2}] [{3}] [{4}]", result, match.Groups["sign"], match.Groups["head"], match.Groups["tail"], match.Groups["exponent"]);
			int exponent = int.Parse(match.Groups["exponent"].Value, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
			StringBuilder builder = new StringBuilder(result.Length+Math.Abs(exponent));
			builder.Append(match.Groups["sign"].Value);
			if (exponent >= 0) {
				builder.Append(match.Groups["head"].Value);
				string tail = match.Groups["tail"].Value;
				if (exponent < tail.Length) {
					builder.Append(tail, 0, exponent);
					builder.Append(formatInfo.NumberDecimalSeparator);
					builder.Append(tail, exponent, tail.Length-exponent);
				} else {
					builder.Append(tail);
					builder.Append('0', exponent-tail.Length);
				}
			} else {
				builder.Append('0');
				builder.Append(formatInfo.NumberDecimalSeparator);
				builder.Append('0', (-exponent)-1);
				builder.Append(match.Groups["head"].Value);
				builder.Append(match.Groups["tail"].Value);
			}
			result = builder.ToString();
		}
		return result;
	}
    // test code
    double x = 1.0;
    for (int i = 0; i < 200; i++) {
        x /= 10;
    }
    Console.WriteLine(x);
    Console.WriteLine(ToFloatingPointString(x));
