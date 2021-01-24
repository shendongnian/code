    class MyClass
    {
        static void Print(MyClass instance)
        {
            Console.WriteLine(instance.ToString());  //Compiles, because it references an object that was passed in
        }
    }
