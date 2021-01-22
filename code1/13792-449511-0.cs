public class Listener
{
    public virtual void Process(Base obj) { }
    public virtual void Process(Derived obj) { }
    public virtual void Process(OtherDerived obj) { }
}
public class Base
{
    public virtual void Dispatch(Listener l) { l.Process(this); }
}
public class Derived
{
    public override void Dispatch(Listener l) { l.Process(this); }
}
public class OtherDerived
{
    public override void Dispatch(Listener l) { l.Process(this); }
}
public class ExampleListener
{
    public override void Process(Derived obj)
    {
        Console.WriteLine("I got a Derived");
    }
    public override void Process(OtherDerived obj)
    {
        Console.WriteLine("I got an OtherDerived");
    }
    public void ProcessCollection(IEnumerable<Base> collection)
    {
        foreach (Base obj in collection) obj.Dispatch(this);
    }
}
