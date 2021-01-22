		public class Results
		{
			public string SampleProperty1 { get; set; }
			public string SampleProperty2 { get; set; }
		}
		
		public class MyResults : Results
		{
			public MyResults(Results results)
			{
				SampleProperty1 = results.SampleProperty1;
				SampleProperty2 = results.SampleProperty2;
			}
		}
