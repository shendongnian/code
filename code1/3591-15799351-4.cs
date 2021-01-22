	public class Trendline
	{
		public Trendline(IList<decimal> yAxisValues, IList<decimal> xAxisValues)
			: this(yAxisValues.Select((t, i) => new Tuple<decimal, decimal>(xAxisValues[i], t)))
		{ }
		public Trendline(IEnumerable<Tuple<Decimal, Decimal>> data)
		{
			var cachedData = data.ToList();
			
			var n = cachedData.Count;
			var sumX = cachedData.Sum(x => x.Item1);
			var sumX2 = cachedData.Sum(x => x.Item1 * x.Item1);
			var sumY = cachedData.Sum(x => x.Item2);
			var sumXY = cachedData.Sum(x => x.Item1 * x.Item2);
			
			//b = (sum(x*y) - sum(x)sum(y)/n)
			//		/ (sum(x^2) - sum(x)^2/n)
			Slope = (sumXY - ((sumX * sumY) / n))
						/ (sumX2 - (sumX * sumX / n));
			
			//a = sum(y)/n - b(sum(x)/n)
			Intercept = (sumY / n) - (Slope * (sumX / n));
			Start = GetYValue(cachedData.Min(a => a.Item1));
			End = GetYValue(cachedData.Max(a => a.Item1));
		}
		
		public decimal Slope { get; private set; }
		public decimal Intercept { get; private set; }
		public decimal Start { get; private set; }
		public decimal End { get; private set; }
		
		public decimal GetYValue(decimal xValue)
		{
			return Intercept + Slope * xValue;
		}
	}
