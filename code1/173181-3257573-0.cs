    enum InterceptorType
    {
        foo,
        bar,
        zee,
        brah
    }
    public static void Main()
    {
        while (true)
        {
            int command = int.Parse(Console.ReadLine());
            if (command == -1)
                Environment.Exit(0);
            else
                addInterception((InterceptorType)command, "some location", "0");
        }
    }
    private static void addInterception(InterceptorType type, string Location, string Number)
    {
        switch(type)
        {
            case InterceptorType.foo: Console.WriteLine("bind foo"); break;
            case InterceptorType.bar: Console.WriteLine("bind bar"); break;
            default: Console.WriteLine("default bind zee"); break;
        }
    }
    static void interceptor_MessageReceived(object sender, EventArgs e)
    {
        //Do something 
    } 
