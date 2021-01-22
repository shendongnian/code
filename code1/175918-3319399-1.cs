    public interface IAnmial : ICloneable
    {
        string Name{get; set;}
        object Clone();
    }
    public class Monkey : IAnmial
    {
        public string Name{get; set;}
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class Dog : IAnmial
    {
        public string Name{get; set;}
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class Test()
    {
        public void CloneAnimal()
        {
            Dog dog = new Dog()
            {
                Name = "MyAnimal",
            };
            IAnimal monkey = dog.Clone() as IAnimal;
        }
    }
