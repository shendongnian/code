	public static class ExtensionMethods
	{
		static public MyType<TDataAdd,MyType<TDataIn,TResultIn>> AddColumn<TDataIn,TResultIn,TDataAdd>(this MyType<TDataIn,TResultIn> This, TDataAdd columnValue)
		{
			return MyTypeFactory.Create(columnValue, This);
		}
	}
    var grandparent = MyTypeFactory.Create( 12 )
        .AddColumn( 13D )
        .AddColumn( 14M )
        .AddColumn( 15F );
	var grandchildValue = grandparent.Child.Child.Child.Data;
	Console.WriteLine(grandchildValue);                       //12
	Console.WriteLine(grandchildValue.GetType().FullName);    //System.Int32
