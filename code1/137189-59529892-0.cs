cil
.class public auto ansi sealed GenericDelegate extends [mscorlib]System.MulticastDelegate
{
.method public hidebysig specialname rtspecialname instance void .ctor(object 'object', native int 'method') runtime managed
{
}
.method public hidebysig newslot virtual instance !!T Invoke<T>(!!T arg) runtime managed
{
}
}
To my surprise, C# can actually consume this type without issues – you can create an instance of this type from a generic method (with matching constraints) and the program compiles. However, the result is an invalid CIL, as constructing the delegate uses the `ldftn` instruction but the generic method has no executable code associated with it, as it is generic.
Even though I couldn't find anything in ECMA-335 that would explicitly prohibit the delegate, the runtime rejects it. The problem is that the `runtime` attribute on `Invoke` specifies that the implementation for this method is provided by the runtime, but this isn't supported when the method is generic. While `ldftn` *could* be modified to allow generic methods and the implementation of `Invoke` *could* be provided in this case, it simply isn't.
---
I agree however that sometimes this concept is useful. While the runtime will not help you with it, probably the easiest way is to simply use an interface:
cs
class Foo
{
    public T Factory<T>(string name)
    {
    }
}
class FooFactory : IGenericFunc<string>
{
    readonly Foo target;
    public FooFactory(Foo target)
    {
        this.target = target;
    }
    public T Invoke<T>(string name)
    {
        return target.Factory<T>(name);
    }
}
interface IGenericFunc<TArg>
{
    T Invoke<T>(TArg arg);
}
Create an interface for every variation of arguments you need, and an implementation for every method you need to call. If you also want to have something akin to `Delegate.CreateDelegate`, you will most likely have to use `System.Reflection.Emit` to have it somewhat performant.
