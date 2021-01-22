internal static TwitterTrendTimeframe ConvertWeakTrend(object value)
{
	Dictionary&lt;string, object&gt; valueDictionary = (Dictionary&lt;string, object&gt;)value;
	DateTime date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((int)valueDictionary["as_of"]);
	object[] trends = (object[])((Dictionary&lt;string, object&gt;)valueDictionary["trends"])[date.ToString("yyyy-MM-dd HH:mm:ss")];
	TwitterTrendTimeframe convertedResult = new TwitterTrendTimeframe()
	{
		EffectiveDate = date,
		Trends = new Collection&lt;TwitterTrend&gt;()
	};
	for (int i = 0; i &lt; trends.Length; i++)
	{
		Dictionary&lt;string, object&gt; item = (Dictionary&lt;string, object&gt;)trends[i];
		TwitterTrend trend = new TwitterTrend()
		{
			Name = (string)item["name"]
		};
		if (item.ContainsKey("url"))
		{
			trend.Address = (string)item["url"];
		}
		if (item.ContainsKey("query"))
		{
			trend.SearchQuery = (string)item["query"];
		}
		convertedResult.Trends.Add(trend);
	}
	return convertedResult;
}
