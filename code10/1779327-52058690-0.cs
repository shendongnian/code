	using System;
	class BaseClass
	{
		public string name;
		public BaseClass()
		{
			this.name = "MyName";
		}
		public virtual void A()
		{
			Console.WriteLine($"Hi {base.name}, I don't know your surname here");
		}
	}
	class DerivedClass : BaseClass
	{
		public string surname;
		public DerivedClass()
		{
			this.surname = "MySurname";
		}
		
       // HERE:
		public override void A()
		{
            // the 'this' and 'base' are just for clarification and are optional.
			Console.WriteLine($"Hi {base.name} {this.surname}, how are you.");
		}
	}
	namespace HelloWorld
	{
		class Program
		{
			static void Main(string[] args)
			{
				DerivedClass dc = new DerivedClass();
				dc.A();
                // It's even possible to store the derived class in a base class variable
                BaseClass bc = new DerivedClass();
				bc.A(); // it will still execute the overriden method.
				Console.ReadKey();
			}
		}
	}
