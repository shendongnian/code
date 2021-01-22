    class Animal {
        public virtual void Speak() {
            Console.WriteLine("i can haz cheezburger?");
        } 
    }
    class Feeder {
        public void Feed(Animal a) { b.Speak(); }
    }
    class Cat : Animal {
        public override void Speak() { Console.WriteLine("Meow!"); }
    }
    class Dog : Animal {
        public override void Speak() { Console.WriteLine("Woof!"); }
    }
    
