    public abstract class Pet
    {    
        public string Name {get;set;}
        public Pet(string name)
        {
            this.Name=name;
        }
        public void Eat()
        {
            Console.WriteLine(String.Format("{0}: nom nom nom", Name));
        }
        public abstract void Speak();
    }
    
    public class Dog: Pet
    {
        public Dog(string name):base(name){}
    
        public override void Speak()
        {
            Bark();
        }
        public void Bark()
        {
            Console.WriteLine(String.Format("{0}: bark", Name));
        }
    }
    
    public class Cat: Pet
    {
        public Cat(string name):base(name){}
    
        public override void Speak()
        {
            Meow();
        }
        public void Meow()
        {
            Console.WriteLine(String.Format("{0}: meow", Name));
        }
    }
