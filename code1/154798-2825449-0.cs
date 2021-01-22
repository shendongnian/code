    dynamic d = new Foo();
    var sum = (int)d.GetType()
                    .GetMethod("Sum")
                    .Invoke(d, new object[] { 1, 3 });
    Console.WriteLine(sum);
