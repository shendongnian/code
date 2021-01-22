    abstract class Animal{
        public abstract void Speak();
    }
    class Cat : Animal{
        public override void Speak(){Console.WriteLine("meow");}
    }
    class Dog : Animal{
        public override void Speak(){Console.WriteLine("bark");}
    }
