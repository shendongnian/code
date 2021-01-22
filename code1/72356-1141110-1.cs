    public abstract class AbstractClass
    {
        public void AbstractMethod()
        {
            MustBeCalled();
            InternalAbstractMethod();
        }
        
        protected abstract void InternalAbstractMethod();
        public void MustBeCalled()
        {
            //this must be called when AbstractMethod is invoked
        }
    }
    
    public class ImplementClass : AbstractClass
    {
        protected override void InternalAbstractMethod()
        {
            //when called, base.MustBeCalled() must be called.
            //how can i enforce this?
        }
    }
