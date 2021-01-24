	class MyClassForJson
	{
		public string Schema { get; set; }
		public IEnumerable<MyInnerClassForJson> Entities { get; set; }
	}
	class MyInnerClassForJson
	{
		public string Type { get; set; }
		public IEnumerable<MyInnerInnerClassForJson> Properties { get; set; }
	}
	class MyInnerInnerClassForJson
	{
		public string Type { get; set; }
		public IEnumerable<string> Value { get; set; }
	}
