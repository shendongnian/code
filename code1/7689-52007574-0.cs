    //file1.cs
    namespace Foo
    {
        class Foo
        {
        }
    }
    //file2.cs
    namespace ConsoleApp3
    {
        using Foo;
        class Program
        {
            static void Main(string[] args)
            {
                //This will allow you to use the class
                Foo test = new Foo();
            }
        }
    }
    //file2.cs
    using Foo; //Unused and redundance    
    namespace Bar
    {
        class Bar
        {
            Bar()
            {
                Foo.Foo test = new Foo.Foo();
                Foo test = new Foo(); //will give you an error that a namespace is being used like a class.
            }
        }
    }
