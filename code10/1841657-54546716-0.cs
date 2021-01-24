C#
public void Method<T>(T param)
{
    switch (param)
    {
        case A a:
            Console.WriteLine("A");
            break;
        case B b:
            Console.WriteLine("B");
            break;
    }
}
