namespace Base.Assembly
{
  public abstract class Parent
  {
    internal abstract void SomeMethod();
  }
  //This works just fine since it's in the same assembly.
  public class ChildWithin : Parent
  {
    internal override void SomeMethod()
    {
    }
  }
}
namespace Another.Assembly
{
  //Kaboom, because you can't override an internal method
  public class ChildOutside : Parent
  {
  }
  public class Test 
  { 
   
    //Just fine
    private Parent _parent;
    public Test()
    {
      //Still fine
      _parent = new ChildWithin();
    }
  }
}
