	public interface ICat {
		void Meow();
		int Age { get; set; }
	}
	public interface IDog {
		void Bark();
		int Weight { get; set; }
	}
	public interface ICatDog : ICat, IDog {
	}
	public class Cat : ICat {
		#region ICat Members
		public void Meow() {
			Console.WriteLine("Meow");
		}
		public int Age {
			get;
			set;
		}
		#endregion
	}
	public class Dog : IDog {
		#region IDog Members
		public void Bark() {
			Console.WriteLine("Woof");			
		}
		public int Weight {
			get;
			set;
		}
		#endregion
	}
