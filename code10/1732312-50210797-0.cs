	public class BaseClass 
	{
		private int id;
		public int Id 
		{ 
			get { return id; }
			set { id = value; SomethingChanged(this, "id"); }
		}
		
		public event EventHandler<string> SomethingChanged;
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
				//// cannot be invoked directly here
				// SomethingChanged(this, "name"); 
			}
		}
	}
