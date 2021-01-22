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
