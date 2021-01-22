    using ImpromptuInterface.Dynamic;
...
    var f = ImpromptuGet.Create<IFoo>(new{ 
                    Foo = "foo",
                    Print = ReturnVoid.Arguments(() => Console.WriteLine(Foo))
                });
