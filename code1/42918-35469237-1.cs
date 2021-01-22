	public class MyClass 
	{
		public int Property1 { get; set; }
		public string Property2 { get; set; }
		public int[] Property3 { get; set; }
		public Subclass Property4 { get; set; }
		public Subclass[] Property5 { get; set; }
	}
	public class Subclass
	{
		public int PropertyA { get; set; }
		public string PropertyB { get; set; }
	}
    // result is Property1
	this.NameOf((MyClass o) => o.Property1);
    // result is Property2
	this.NameOf((MyClass o) => o.Property2);
    // result is Property3
	this.NameOf((MyClass o) => o.Property3);
    // result is Property4
	this.NameOf((MyClass o) => o.Property4);
    // result is PropertyB
	this.NameOf((MyClass o) => o.Property4.PropertyB);
    // result is Property5
	this.NameOf((MyClass o) => o.Property5);
