    partial class Foo
    {
        partial void Bar(string someArg);
    }
    partial class Foo
    {
        partial void Bar(string someArg)
        {
            Console.WriteLine(someArg);
        }
    }
