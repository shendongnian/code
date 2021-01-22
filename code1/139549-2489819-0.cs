    internal static class HarvestorFactory
	{
		private static Dictionary<HarvestingSource, IHarvester> harvesters = 
			new Dictionary<HarvestingSource, IHarvester>
			{
				{ HarvestingSource.Google, new GoogleHarvester() },
				{ HarvestingSource.Yahoo, new YahooHarvester() },
				{ HarvestingSource.Bing, new BingHarvester() },
			};
		internal static IHarvester Get( HarvestingSource source )
		{
			return harvesters[ source ];
		}
	}
