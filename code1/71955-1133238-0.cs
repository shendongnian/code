    public abstract class parentClass
    {
        //...other stuff...
        protected abstract void doSomething(); //or use virtual instead of abstract and give the method a body
    }
    public class childClass : parentClass
    {
        //...other stuff...
        protected override void doSomething()
        {
           //...do something
        }
    }
