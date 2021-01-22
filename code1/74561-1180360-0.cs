	public class Animal {
		protected Animal() { }
		public Animal(string name, string species) {
			_Name = name;
			_Species = species;
		}
		public virtual string Name {
			get { return _Name; }
			set { _Name = value; }
		}
		private string _Name;
		public virtual string Species {
			get { return _Species; }
			set { _Species = value; }
		}
		private string _Species;
	}
	public sealed class NullAnimal : Animal {
		public override string Name {
			get { return String.Empty; }
			set { }
		}
		public override string Species {
			get { return String.Empty; }
			set { }
		}
	}
