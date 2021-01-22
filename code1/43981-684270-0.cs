    public abstract class AbstractWidget : IDoesCoolThings
    {
        public void DoCool()      // DoCool() is part of the abstract class implementation.
        {
            Console.Write("I did something cool.");
        }
    }
    // ...
    
    var rw = new RealWidget();
    rw.DoCool();                  // Works!
