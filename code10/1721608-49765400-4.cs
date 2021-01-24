    public class MyType<TData,TChild>
	{
		public MyType(TData data, TChild child)
		{
		}
	}
	
	public class MyTypeFactory
	{
	   public static MyType<TData,TChild> Create<TData,TChild>(TData data, TChild child)
	   {
		  return new MyType<TData,TChild>(data, child);
	   }
		
	   public static MyType<TData,object> Create<TData>(TData data)
	   {
		  return new MyType<TData,object>(data, null);
	   }
	}
	
	public static class Program
	{
		static public void Main()
		{
			var grandchild  = MyTypeFactory.Create( 12 );
			var child       = MyTypeFactory.Create( 13D, grandchild );
			var parent      = MyTypeFactory.Create( 14M, child) ;
			var grandparent = MyTypeFactory.Create( 15F, parent );
			
			Console.WriteLine(  grandchild.GetType().FullName );
			Console.WriteLine(       child.GetType().FullName );
			Console.WriteLine(      parent.GetType().FullName );
			Console.WriteLine( grandparent.GetType().FullName );
		}
	}
