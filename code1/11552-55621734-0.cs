C#
public interface IFoo
{
    string Prop1 { get; }
    string MakeNewString(string old);
}
public class Foo : IFoo
{
    private readonly Func<string> _prop1;
    private readonly Func<string, string> _makeNewString;
    public Foo(Func<string> prop1, Func<string, string> makeNewString)
    {
        _prop1 = prop1;
        _makeNewString = makeNewString;
    }
    public string Prop1 => _prop1();
    public string MakeNewString(string old) => _makeNewString(old);
}
Then, to use it:
C#
public static void Example()
{
    // Make string implement IFoo
    string myString = "hello world";
    IFoo foo = new Foo(() => myString, (str) => myString + str);
    // Make int implement IFoo
    int myInt = 8;
    IFoo bar = new Foo(() => myInt.ToString(), (str) => myInt.ToString() + str);
}
