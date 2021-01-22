	namespace MyNamespace
	{
		struct MyValueType : ICloneable
		{
			public int A;
			public int B;
			public int C;
			
			public object Clone()
			{
				// body omitted
			}
		}
	}
