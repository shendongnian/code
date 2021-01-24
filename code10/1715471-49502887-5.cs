    class MyClass
    {
        static private MyClass _anInstance = new MyClass();
        static void Print()
        {
            Console.WriteLine(_anInstance.ToString());  //Compiles, because it references an object instance held in a static variable
        }
    }
    
