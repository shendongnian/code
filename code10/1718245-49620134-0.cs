	public class Page
	{
		public T Button<T>(T template) where T : class
		{
			return (T)Activator.CreateInstance
			(
				typeof(T), 
				new object[] 
				{ 
					"Button text", 
					new Action(() => Console.WriteLine("This is a click handler")), 
					false 
				} 
			);
		}
	}
	
	public class Program
	{
		static public void Main()
		{
			var template = new 
			{ 
				Text = (string)null, 
				Click = (Action)null, 
				Displayed = false 
			} ;
			
			var page = new Page();
			var b = page.Button( template );
			
			Console.WriteLine(b.Text);
			Console.WriteLine(b.Displayed);
			b.Click();
		}
	}
