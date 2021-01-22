C#
public interface DummyInterface
{
    string A { get; }
    string B { get; }
}
// "Generic" implementing class
public class Dummy : DummyInterface
{
    private readonly Func<string> _getA;
    private readonly Func<string> _getB;
    public Dummy(Func<string> getA, Func<string> getB)
    {
        _getA = getA;
        _getB = getB;
    }
    public string A => _getA();
    public string B => _getB();
}
public class DummySource
{
    public string A { get; set; }
    public string C { get; set; }
    public string D { get; set; }
}
public class Test
{
    public void WillThisWork()
    {
        var source = new DummySource[0];
        var values = from value in source
                     select new Dummy // Syntax changes slightly
                     (
                         getA: () => value.A,
                         getB: () => value.C + "_" + value.D
                     );
        DoSomethingWithDummyInterface(values);
    }
    public void DoSomethingWithDummyInterface(IEnumerable<DummyInterface> values)
    {
        foreach (var value in values)
        {
            Console.WriteLine("A = '{0}', B = '{1}'", value.A, value.B);
        }
    }
}
If all you are ever going to do is convert `DummySource` to `DummyInterface`, then it would be simpler to just have one class that takes a `DummySource` in the constructor and implements the interface.
But, if you need to convert many types to `DummyInterface`, this is much less boiler plate.
