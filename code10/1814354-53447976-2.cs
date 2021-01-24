	public class Rootobject
	{
		public string symbol { get; set; }
		public string stock_exchange_short { get; set; }
		public string timezone_name { get; set; }
		public Intraday intraday { get; set; }
	}
	public class Intraday
	{
		public _20181121155900 _20181121155900 { get; set; }
		public _20181121155800 _20181121155800 { get; set; }
		public _20181121155700 _20181121155700 { get; set; }
	}
	public class _20181121155900
	{
		public string open { get; set; }
		public string close { get; set; }
		public string high { get; set; }
		public string low { get; set; }
		public string volume { get; set; }
	}
	public class _20181121155800
	{
		public string open { get; set; }
		public string close { get; set; }
		public string high { get; set; }
		public string low { get; set; }
		public string volume { get; set; }
	}
	public class _20181121155700
	{
		public string open { get; set; }
		public string close { get; set; }
		public string high { get; set; }
		public string low { get; set; }
		public string volume { get; set; }
	}
