    ...
	private void InImmutable([System.Runtime.CompilerServices.IsReadOnly] [In] ref MyClass.Immutable x)
	{
		x.SomeMethod();
	}
	private void InMutable([System.Runtime.CompilerServices.IsReadOnly] [In] ref MyClass.Mutable x)
	{
		MyClass.Mutable mutable = x;
		mutable.SomeMethod();
	}
	private void InInt32([System.Runtime.CompilerServices.IsReadOnly] [In] ref int x)
	{
		int num = x;
		num.ToString();
	}
	private void InDateTime([System.Runtime.CompilerServices.IsReadOnly] [In] ref DateTime x)
	{
		DateTime dateTime = x;
		dateTime.ToString();
	}
    ...
