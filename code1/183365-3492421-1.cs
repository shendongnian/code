class Base
{
    private int x;
    private int y;
    // ...
    public Base(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
// option 1, pass in values as parameters to constructor:
class Child1
{
    public Child(int x, int y)
        : base(x, y) // this passes the values up to the base constructor
    {
    }
}
// option 2, pass literals to the base constructor:
class Child2
{
    public Child()
        : base(3, 4) // this passes the literal values 3 and 4 to the base constructor
    {
    }
}
// elsewhere
var child1 = new Child1(1, 2); // child1.x = 1, child1.y = 2
var child2 = new Child2(); // child2.x = 3, child2.y = 4
Now, regarding your second question regarding having a method in the derived class with the same name.  If you wish to redefine the behaviour of a method, you should make it virtual in the base class and override it in the derived class, which you can see from the method called SomeAction in this example:
class Base
{
    public virtual void SomeAction()
    {
        Console.Out.WriteLine("Base.SomeAction");
    }
    public void DifferentAction()
    {
        Console.Out.WriteLine("Base.DifferentAction");
    }
}
class Derived
{
    public override void SomeAction()
    {
        Console.Out.WriteLine("Derivde.SomeAction");
    }
    // this is an advanced technique which you should try to avoid in
    // most cases
    public new void DifferentAcion()
    {
        Console.Out.WriteLine("Derived.DifferentAction");
    }
}
// elsewhere
var base = new Base();
base.SomeAction(); // prints Base.SomeAction
base.DifferentAction(); // prints Base.DifferentAction
var derived = new Derived();
derived.SomeAction(); // prints Derived.SomeAction
derived.DifferentAction(); // prints Derived.DifferentAction
((Base) derived).SomeAction(); // prints Derived.SomeAction
((Base) derived).DifferentAction(); // prints Base.DifferentAction
