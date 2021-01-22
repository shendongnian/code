using System;
public class Base
{
    protected virtual void Foo()
    {
    }
}
public sealed class Derived : Base
{
    protected override void Foo()
    {
    }
}
<p>compiles without warnings with .NET 3.5SP1. Are you <em>definitely</em> overriding the base method? Check that you really have got the override modifier. (Sorry if that sounds patronising - I'm not trying to accuse you of being lax or anything. I'm just stumped otherwise...)</p>
