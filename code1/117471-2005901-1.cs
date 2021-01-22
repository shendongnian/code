    partial class Foo
    {
        partial void Bar(string someArg);
        // other code that uses Bar(s)
    }
    partial class Foo
    {
        partial void Bar(string someArg)
        {
            Console.WriteLine(someArg);
        }
    }
