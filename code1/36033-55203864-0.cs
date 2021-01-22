class Parent
{
    protected int foo = 0;
}
// Child extends from Parent
class Child : Parent
{
    public void SomeThing(Parent p)
    {
        // Here we're trying to access an instance's protected member.
        // So doing this...
        var foo = p.foo;
    }
}
// (this class has nothing to do with the previous ones)
class SomeoneElse
{
    public void SomeThing(Parent p)
    {
        // ...is the same as doing this (i.e. public access).
        var foo = p.foo++;
    }
}
You'd think you'd have access to `p.foo` because you're inside a child class, but you're accessing it from a instance, and that's like a public access, so it's denied.
You're allowed to access `protected` members from within the class, not from an instance (yes, we know this):
class Child : Parent
{
    public void SomeThing()
    {
        // I'm allowed to modify parent's protected foo because I'm
        // doing so from within the class.
        foo++;
    }
}
Finally, for the sake of completeness, you are actually able to access an instance's `protected` and even `private` members only if you're doing so within the same class:
class Parent
{
    protected int foo = 0;
    private int bar = 0;
    public void SomeThing(Parent p)
    {
        // I'm allowed to access an instance's protected and private
        // members because I'm within Parent accessing a Parent instance
        var foo = p.foo;
        p.bar = 3;
    }
}
