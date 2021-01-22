    public class Animal { }
    public class Dog : Animal { }
    public void Test()
    {
        Dog d = new Dog();
        
        Debug.Assert(d is Animal); // true
        Debug.Assert(typeof(Dog) == typeof(Animal); // false
    }
