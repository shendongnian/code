	class Base {
		public virtual void T() { Console.WriteLine("Base"); }
	}
	class Derived : Base {
		public void T() { Console.WriteLine("Derived"); }
	}
	Base d = new Derived();
	d.T();
