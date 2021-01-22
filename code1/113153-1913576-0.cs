    	public static class BindingExtensions
	{
		public static Binding Clone(this Binding binding)
		{
			var cloned = new Binding();
			//copy properties here
			return cloned;
		}
	}
	public void doWork()
	{
		Binding b= new Binding();
		Binding nb = b.Clone(); 
	}
