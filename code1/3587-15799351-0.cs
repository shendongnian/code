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
			
			B = (sumXY - ((sumX * sumY) / n))
						/ (sumX2 - (sumX * sumX / n));
			
			A = (sumY / n) - (B * (sumX / n));
			
			RandomTest(cachedData);
		}
		
		public decimal A { get; private set; }
		public decimal B { get; private set; }
		
		public decimal GetYValue(decimal xValue)
		{
			return A + B * xValue;
		}
	}
