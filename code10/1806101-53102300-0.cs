	class BaseClass
	{
		public int Property { get; protected set; }
	}
	class InterClass : BaseClass
	{
		protected void DoFunnyStuff(int value)
		{
			this.Property = value;
		}
	}
	class DerivedClass : InterClass
	{
		public new int Property { get; set; } //Hides BaseClass.Property
		public static DerivedClass Build()
		{
			DerivedClass result = new DerivedClass
			{
				Property = 17
				//base.Property = 17; // this doesn't compile
			};
			result.DoFunnyStuff(17);
			return result;
			//((BaseClass)result).Property = 17; // this doesn't compile
		}
	}
