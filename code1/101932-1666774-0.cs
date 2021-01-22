    class Cat : IAnimal
	{
		public void Move()
		{
			//a cat moves by walking
			this.Walk();
		}
		public void Walk()
		{
			//do logic
		}
	}
    class Bird : IAnimal
	{
		public void Move()
		{
			this.Fly();
		}
		public void Fly()
		{
			//do fly logic
		}
	}
