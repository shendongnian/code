    enum Pets
	{
		None,
		Cat = 1,
		Dog = 2
	}
	enum Sizes
	{
		None,
		Big = 1,
		Small = 2
	}
	class PetType
	{
		public PetType(Pets type)
		{
			Type = type;
		}
		public Pets Type { get; set; } = Pets.None;
	}
	class Pet
	{
		public Pet(PetType type, Sizes size)
		{
			Type = type;
			Size = size;
		}
		public PetType Type { set; get; }
		public Sizes Size { set; get; } = Sizes.None;
	}
	class SomeClass
	{
		public Pet ThePet { get; set; }
	}
