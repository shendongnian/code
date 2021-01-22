		public class FxRate
		{
			public string Base { get; set; }
			public string Target { get; set; }
			public double Rate { get; set; }
		}
		private List<FxRate> rates = new List<FxRate>
    	                             	{
    	                             		new FxRate {Base = "EUR", Target = "USD", Rate = 1.3668},
    	                             		new FxRate {Base = "GBP", Target = "USD", Rate = 1.5039},
    	                             		new FxRate {Base = "USD", Target = "CHF", Rate = 1.0694},
    	                             		new FxRate {Base = "CHF", Target = "SEK", Rate = 8.12}
    	                             		// ...
    	                             	};
		public List<List<FxRate>> Rates(string baseCode, string targetCode)
		{
			return Rates(baseCode, targetCode, rates.ToArray());
		}
		public List<List<FxRate>> Rates(string baseCode, string targetCode, FxRate[] toSee)
		{
			List<List<FxRate>> results = new List<List<FxRate>>();
			List<FxRate> possible = toSee.Where(r => r.Base == baseCode).ToList();
			List<FxRate> hits = possible.Where(p => p.Target == targetCode).ToList();
			if (hits.Count > 0)
			{
				possible.RemoveAll(hits.Contains);
				results.AddRange(hits.Select(hit => new List<FxRate> { hit }));
			}
			FxRate[] newToSee = toSee.Where( item => !possible.Contains(item)).ToArray();
			foreach (FxRate posRate in possible)
			{
				List<List<FxRate>> otherConversions = Rates(posRate.Target, targetCode, newToSee);
				FxRate rate = posRate;
				otherConversions.ForEach(result => result.Insert(0, rate));
				results.AddRange(otherConversions);
			}
			return results;
		}
