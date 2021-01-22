    class Base
    {
    public virtual int X
    {
    get
    {
    Console.Write("Base GET");
    return 10;
    }
    set
    {
    Console.Write("Base SET");
    }
    }
    }
    class Derived : Base
    {
    public override int X
    {
    get
    {
    Console.Write("Derived GET");
    return 10;
    }
    set
    {
    Console.Write("Derived SET");
    }
    }
    }
