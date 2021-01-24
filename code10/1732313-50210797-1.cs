	public class BaseClass 
	{
		private int id;
		public int Id 
		{ 
			get { return id; }
			set { id = value; OnSomethingChanged( "id"); }
		}
		
		public event EventHandler<string> SomethingChanged;
		
		protected virtual void OnSomethingChanged(string something)
		{
			SomethingChanged(this, something);
		}
	}
	
	public class DerivedClass : BaseClass
	{
		private string name;
		public string Name 
		{ 
			get { return name; }
			set 
			{ 
				name = value; 
				OnSomethingChanged("name"); 
			}
		}
		
		protected override void OnSomethingChanged(string something)
		{
			base.OnSomethingChanged(something + " (event triggered from derived class)");
		}
	}
<!---->
	public static void Main(string[] args)
	{
		var item = new DerivedClass();
		item.SomethingChanged += (e,s) => Console.WriteLine(s);
		item.Id = 5;
		item.Name = "abc";
	}
