    class Animal {}
    class Mammal : Animal {}
    class Tiger : Mammal {}
    class Giraffe : Mammal {}
    class C : I1<Mammal> {
        public Mammal M1() { return new Tiger(); }
    }
    I1<Mammal> i1m = new C(); // Legal
    I1<Animal> i1a = i1m; // Legal
    Animal a = i1a.M1(); // Returns a tiger; assigned to animal, good!
