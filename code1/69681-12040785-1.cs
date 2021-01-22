		private abstract class A
		{
			public int P1 { get; set; }
			public abstract A CreateInstance();
			public virtual A Clone()
			{
				var instance = CreateInstance();
				instance.P1 = this.P1;
				return instance;
			}
		}
		private class B : A
		{
			public int P2 { get; set; }
			public override A CreateInstance()
			{
				return new B();
			}
			public override A Clone()
			{
				var result = (B) base.Clone();
				result.P2 = P2;
				return result;
			}
		}
		private static void Main(string[] args)
		{
			var b = new B() { P1 = 111, P2 = 222 };
			var c = b.Clone();
		}
