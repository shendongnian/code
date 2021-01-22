    class MyClass
	{
		public MyClass()
		{
			myInt = 7;
		}
		int? _myInt;
		protected int myInt
		{
			set { _myInt = value; }
			get { return _myInt ?? 0; }
		}
		int? _myOtherInt;
		protected int myOtherInt
		{
			set { _myOtherInt = value; }
			get { return _myOtherInt ?? 0; }
		}
	}
