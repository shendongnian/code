    public abstract class BaseAction
    {
        protected void Foo()
        {
            Console.WriteLine(this.GetType());
        }
    }
    public class Action : BaseAction 
    {
        public void Bar() 
        {
            Foo();
        }
    }
    // the runtime type of foo will be Action regardless of compile-time type
    BaseAction foo = new Action(); 
    foo.Bar();
