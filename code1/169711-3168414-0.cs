    ...
    foreach (var type in types)
            {
                var t = type;
                var sayHello = new PrintHelloType(greeting => SayGreetingToType(t, greeting));
                helloMethods.Add(sayHello);
            }
    ....
