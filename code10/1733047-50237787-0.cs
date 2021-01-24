	public class Cat
	{
		private string name;
		public Cat(string name)
		{
			this.name = name;
		}
		
		public string SayName()
		{
			return $"Meow my name is {name}";
		}
	}
	// fixed size array
	var cats = new Cat[3];
	cats[0] = new Cat("pete");
	cats[1] = new Cat("dave");
	cats[2] = new Cat("mike");
	//dynamic size array
	var cats = new List<Cat>();
	cats.Add(new Cat("pete"));
	cats.Add(new Cat("dave"));
	cats.Add(new Cat("mike"));
	var catArray = cats.ToArray();
