	//example of the base class
	public abstract class MyAbstractBaseClass
	{
		private static readonly IDictionary<Type,IList<MyAbstractBaseClass>> values = new Dictionary<Type,IList<MyAbstractBaseClass>>();
		public List<string> MyParameterNames 
		{
			get
			{
				return values[this.GetType()].Select(x => x.Name).ToList();
			}
		}
		public string Name {get; private set;}
		protected MyAbstractBaseClass(string name)
		{
			//assign the new item's name to the variable
			Name = name;
			//keep a list of all derivations of this class
			var key = this.GetType();
			if (!values.ContainsKey(key))
			{
				values.Add(key, new List<MyAbstractBaseClass>());
			}
			values[key].Add(this);
		}
	}
	
	//examples of dervived class implementations
	public class MyDerivedClassOne: MyAbstractBaseClass
	{
		private MyDerivedClassOne(string name): base(name){}
		public static readonly MyDerivedClassOne Example1 = new MyDerivedClassOne("First Example");
		public static readonly MyDerivedClassOne Example2 = new MyDerivedClassOne("Second Example");
	}
	public class MyDerivedClassTwo: MyAbstractBaseClass
	{
		private MyDerivedClassTwo(string name): base(name){}
		public static readonly MyDerivedClassTwo Example1 = new MyDerivedClassTwo("1st Example");
		public static readonly MyDerivedClassTwo Example2 = new MyDerivedClassTwo("2nd Example");
	}
	
	//working example
	void Main()
	{
		foreach (var s in MyDerivedClassOne.Example1.MyParameterNames)
		{
			Console.WriteLine($"MyDerivedClassOne.Example1.MyParameterNames: {s}.");
		}
		foreach (var s in MyDerivedClassTwo.Example1.MyParameterNames)
		{
			Console.WriteLine($"MyDerivedClassTwo.Example1.MyParameterNames: {s}.");
		}
	}
	
