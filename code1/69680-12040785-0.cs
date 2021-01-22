		private abstract class A
		{
			public int A1 { get; set; }
			public abstract A CreateInstance();
			public virtual A Clone()
			{
				var instance = CreateInstance();
				instance.A1 = A1;
				return instance;
			}
		}
		private class B : A
		{
			public int A3 { get; set; }
			public override A CreateInstance()
			{
				return new B();
			}
			public override A Clone()
			{
				var result = (B) base.Clone();
				result.A3 = A3;
				return result;
			}
		}
		private static void Main(string[] args)
		{
			var b = new B() { A1 = 1, A3 = 2 };
			var c = b.Clone();
		}
