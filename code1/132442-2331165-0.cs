    // No capture :
    int a = 1;
    Action<int> action = delegate(int a)
    {
        a = 42; // method parameter a
    });
    action(a);
    Console.WriteLine(a); // 1
    // Capture of local variable a :
    int a = 1;
    Action action = delegate()
    {
        a = 42; // captured local variable a
    };
    action();
    Console.WriteLine(a); // 42
