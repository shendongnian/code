    public class WrapAnotherClass : AnotherClass
    {
        public EventHandler DoSomethingFinished;
        public new void DoSomething()
        {
            base.DoSomething();
            var temp = DoSomethingFinished;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }
    }
    public class AnotherClass
    {
        public void DoSomething()
        {
            Console.WriteLine("Do something!");
        }
    }
