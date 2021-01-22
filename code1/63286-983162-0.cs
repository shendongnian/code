    class Animal{}
    class Dog : Animal{}
    static void Foo(){
        object o = new Dog();
        if(o.GetType() == typeof(Animal))
            Console.WriteLine("o is an animal");
        Console.WriteLine("o is something else");
    }
