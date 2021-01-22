    class Dog : Animal{}
    Animal dog = new Dog();
    dog.GetType().IsInstanceOfType(Animal);   // true
    dog.GetType().IsInstanceOfType(Dog);      // true
    Animal.IsAssignableFrom(dog.GetType()); // true
    Dog.IsAssignableFrom(dog.GetType());    // true
    dog.GetType().(IsSubClassOf(Animal));   // true
    dog.GetType().(IsSubClassOf(Dog));      // false
