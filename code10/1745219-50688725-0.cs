    class Program
    {
        static void Main(string[] args)
        {
            SomethingClass somethingClass = new SomethingClass();
            somethingClass.PrintThisText("HEY THERE");
            
        }
    }
    public class SomethingClass
    {
        readonly SomeOtherClass _someOtherClass;
        public SomethingClass ()
	    {
            this._someOtherClass = new SomeOtherClass();
	    }
        public void PrintThisText(string text)
        {
            this._someOtherClass.printText(text);
        }
    }
    
    public class SomeOtherClass
    {
        public void printText (string text)
        {
            Console.WriteLine(text);
        }
    }
