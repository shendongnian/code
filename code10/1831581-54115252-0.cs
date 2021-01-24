class Program
{
    static void Main(string[] args)
    {
        var b = new B();
        b.Set("abc");
        // writes "init" if readonly left in, "abc" otherwise
        Console.WriteLine(b.ToString());
    }
}
struct A
{
    string _s;
    public A(int cap) => _s = "init";
    public void Set(string s) => _s = s;
    public override string ToString() => _s;
}
class B
{
    readonly A a = new A(5);
    public void Set(string s) => a.Set(s);
    public override string ToString() => a.ToString();
}
The reason for this is that with the `readonly`, the call to `a.Set()` is really:
    var tmp = a;
    tmp.Set(); // operates on a clone
which is precisely *because* it wants to guarantee the `readonly` part of the field declaration - as otherwise the call to `Set()` has had the side-effect of changing the value of the readonly field. To avoid this in the simplest way: avoid mutable structs! In recent C# versions (7.2+), you can declare structs as `readonly struct`, which will help you enforce this (it won't compile if you try to do anything dangerous *and* it allows the compiler to remove this extra clone step, and to use a more efficient implementation of the `in` ("ref readonly") modifier).
