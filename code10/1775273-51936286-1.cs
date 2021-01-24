    delegate T D<in T>(); // Suppose this were legal.
    class Animal {}
    class Tiger : Animal {}
    class Giraffe : Animal {} // Plainly all these are legal.
    ...
    D<Animal> da = () => new Tiger(); // A tiger is an animal, so this must be legal.
    D<Giraffe> dg = da; // This is legal because T is declared contravariant in D.
    Giraffe g = dg(); // This is legal, because dg returns a giraffe.
    // Except that it actually returns a tiger, and now we have a tiger in
    // a variable of type giraffe.
