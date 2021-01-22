    class Dog : Animal{}
    Animal dog = new Dog();
    Animal.IsInstanceOfType(dog);  // true
    Dog.IsInstanceOfType(dog);     // true
    Animal.IsAssignableFrom(dog.GetType());  // true
    Dog.IsAssignableFrom(dog.GetType());     // true
    dog.GetType().(IsSubClassOf(Animal));  // true
    dog.GetType().(IsSubClassOf(Dog));     // false
