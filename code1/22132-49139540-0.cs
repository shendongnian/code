	public class MyBase
	{
		protected object PropertyOfBase { get; set; }
		public class MyType
		{
			public void MyMethod(MyBase parameter)
			{
				object p = parameter.PropertyOfBase;  
			}
		}
	}
