    public abstract AnimalDTO
    {
        public static AnimalDTO Create(Animal animal)
        {
            var dog = animal as Dog;
            var cat = animal as Cat;
            if (dog != null)
            {
                 return Dog(dog.Country);
            }
            else
            {
                return Cat(cat.Size);
            }
        }
        public static AnimalDTO Dog(string country) => 
            new Animals.Dog(country);
        public static AnimalDTO Cat(string size) =>
            new Animals.Cat(size);
        public abstract void Switch(Action<string> isDog, Action<string> isCat);
        private static class Animals
        {
            public class Dog : AnimalDTO
            {
                readonly string country;
                public Dog(string country)
                {
                    this.country = country;
                }
                public override void Switch(Action<string> isDog, Action<string> isCat) => isDog(country);
        }
        public class Cat : AnimalDTO
            {
                readonly string size;
                public Dog(string size)
                {
                    this.size = size;
                }
                public override void Switch(Action<string> isDog, Action<string> isCat) => isCat(size);
        }
    }
