		private interface IDeepCopy<T> where T : class
		{
			T DeepCopy();
		}
		private class MyClass : IDeepCopy<MyClass>
		{
			public MyClass DeepCopy()
			{
				return (MyClass)this.MemberwiseClone();
			}
		}
