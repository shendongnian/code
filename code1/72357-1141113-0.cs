    public abstract class AbstractClass
    {
        public void PerformThisFunction()
        {
            MustBeCalled();
            AbstractMethod();
        }
    
        public void MustBeCalled()
        {
            //this must be called when AbstractMethod is invoked
        }
    
        //could also be public if desired
        protected abstract void AbstractMethod();
    }
    
    public class ImplementClass : AbstractClass
    {
        protected override void AbstractMethod()
        {
            //when called, base.MustBeCalled() must be called.
            //how can i enforce this?
        }
    }
