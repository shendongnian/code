    public class Animal { }
    public class Dog : Animal { }
    public void Test()
    {
        Dog d = new Dog();
        
        Assert.IsTrue(d is Animal); // true
        Assert.IsTrue(typeof(d) == typeof(Animal); // false
    }
