    public class Animal {}
    public interface ITrainable {}
    public class Dog : Animal, ITrainable{}
    Animal dog = new Dog();
    typeof(Animal).IsInstanceOfType(dog);     // true
    typeof(Dog).IsInstanceOfType(dog);        // true
    typeof(ITrainable).IsInstanceOfType(dog); // true
    typeof(Animal).IsAssignableFrom(dog.GetType());      // true
    typeof(Dog).IsAssignableFrom(dog.GetType());         // true
    typeof(ITrainable).IsAssignableFrom(dog.GetType()); // true
    dog.GetType().IsSubclassOf(typeof(Animal));            // true
    dog.GetType().IsSubclassOf(typeof(Dog));               // false
    dog.GetType().IsSubclassOf(typeof(ITrainable)); // false
