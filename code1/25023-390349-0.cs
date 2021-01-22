    class Foo 
    {
        public virtual void virtualPrintMe()
        {
            nonVirtualPrintMe();
        }
        public void nonVirtualPrintMe()
        {
            Console.Writeline("FOO");
        }
    }
    class Bar : Foo 
    {
        public override void virtualPrintMe()
        {
            Console.Writeline("BAR");
        }
    }
    List<Foo> list = new List<Foo>();
    // then populate this list with various 'Bar' and other overriden Foos
    foreach (Foo foo in list) 
    {
        foo.virtualPrintMe(); // prints BAR or FOO
        foo.nonVirtualPrintMe(); // always prints FOO
    }
