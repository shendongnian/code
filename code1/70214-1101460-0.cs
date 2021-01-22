    class Program
    {
        static void Main(string[] args)
        {
            Foo myfoo = new Foo();
            myfoo.MethodCall();
    
            myfoo.DelegateAction = () => Console.WriteLine("Do something.");
            myfoo.MethodCall();
            myfoo.DelegateAction();
        }
    }
    
    public class Foo
    {
        public void MethodCall()
        {
            if (this.DelegateAction != null)
            {
                this.DelegateAction();
            }
        }
    
        public Action DelegateAction { get; set; }
    }
