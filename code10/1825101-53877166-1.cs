    public class Dog : Animal { }
    public class Cat : Animal { }
    public class Animal
    {
        public static TAnimal GetAnimal<TAnimal>()
        {
            return new Dog();
        }
    }
