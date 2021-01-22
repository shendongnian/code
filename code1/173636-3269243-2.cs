    protected class Marker
	{
		public string Name { get; set; }
		public string Lat { get; set; }
		public string Long { get; set; }
		public override string ToString()
		{
			return String.Format("['{0}', {1}, {2}]", Name, Lat, Long);
		}
	};
