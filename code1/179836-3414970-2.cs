		[TestMethod]
		public void CreatedMixinShouldntThrow() {
			ICat obj1 = new Cat();
			IDog obj2 = new Dog();
			var actual = MixInFactory.CreateMixin(obj1, obj2);
			((IDog)actual).Bark();
			var weight = ((IDog)actual).Weight;
			((ICat)actual).Meow();
			var age = ((ICat)actual).Age;
		}
		[TestMethod]
		public void CreatedGenericMixingShouldntThrow() {
			ICat obj1 = new Cat();
			IDog obj2 = new Dog();
			var actual = MixInFactory.CreateMixin<ICatDog, ICat, IDog>(obj1, obj2);
			
			actual.Bark();
			var weight = actual.Weight;
			actual.Meow();
			var age = actual.Age;
			
		}
