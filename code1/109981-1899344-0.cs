public class Base
{
    protected int Foo;
    protected static int GetFoo(Base b)
    {
        return b.Foo;
    }
}
public class Der : Base
{
    private void B(Base b) { Foo = GetFoo(b); } // OK
}
