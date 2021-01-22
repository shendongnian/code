		[WebMethod]
		public object example()
		{
			return new foo
				   {
					   bar = "bar",
					   baz = "baz"
				   };
		}
		public class foo
		{
			public string bar { get; set; }
			public string baz { get; set; }
		}
