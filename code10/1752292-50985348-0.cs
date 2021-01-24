    public class A 
    {
        public virtual void DoStuff() 
        {
           //some code
        }
    }
    
    public class B : A 
    {
        public override void DoStuff() : base()
        {
             base.DoStuff()
        }
    }
