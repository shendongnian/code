		[TestMethod]
		public void CreatedMixinShouldntThrow() {
			ICat obj1 = new Cat();
			IDog obj2 = new Dog();
			var actual = MixinFactory.CreateMixin(obj1, obj2);
			((IDog)actual).Bark();
			var weight = ((IDog)actual).Weight;
			((ICat)actual).Meow();
			var age = ((ICat)actual).Age;
		}
		[TestMethod]
		public void CreatedGeneric3MixinShouldntThrow() {
			ICat obj1 = new Cat();
			IDog obj2 = new Dog();
			IMouse obj3 = new Mouse();
			var actual = MixinFactory.CreateMixin<ICatDogMouse>(obj1, obj2, obj3);
			actual.Bark();
			var weight = actual.Weight;
			actual.Meow();
			var age = actual.Age;
			actual.Squeek();
		}
