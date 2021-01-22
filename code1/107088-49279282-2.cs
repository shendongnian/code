	void Main()
	{
		List<Cat> cats = new List<Cat> { new Cat() };
		IEnumerable<Mammal> mammalsEnumerable =
			AddDogs(cats); // AddDogs() takes an IEnumerable<Mammal>
		Console.WriteLine(mammalsEnumerable.Count()); // Output: 3. One cat, two dogs.
	}
	public IEnumerable<Mammal> AddDogs(IEnumerable<Mammal> parentSequence)
	{
		List<Dog> dogs = new List<Dog> { new Dog(), new Dog() };
		return parentSequence.Concat(dogs);
	}
