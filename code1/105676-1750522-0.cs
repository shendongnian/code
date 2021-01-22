    abstract class Animal
    {
        public void Mate<T>(T t) where T : this { ... CENSORED ... }
    }
    ...
    Animal x1 = new Giraffe(); 
    Mammal x2 = new Tiger();
    x1.Mate<Mammal>(x2); 
