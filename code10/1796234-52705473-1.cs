	class Animal
	{
		public virtual void Foo() { Console.WriteLine("Animal::Foo()"); }
	}
	class Cat : Animal
	{
		public override void Foo() { Console.WriteLine("Cat::Foo()"); }
	}
	class Test
	{
		static void Main(string[] args)
		{
			Animal a;
			a = new Cat();
			a.Foo();  // output --> "Cat::Foo()"
		}
	}
