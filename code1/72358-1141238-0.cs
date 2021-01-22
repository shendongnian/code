    public abstract class AbstractClass
    {
        public abstract void AbstractMethod();
        
        private void MustBeCalled()
        {
            //will be invoked by  MethodToBeCalled();
            Console.WriteLine("AbstractClass.MustBeCalled");
        }
        
        public void MethodToBeCalled()
        {
            MustBeCalled();
            AbstractMethod();
        }
    }
    
    public class ImplementClass : AbstractClass
    {
        public override void AbstractMethod()
        {
            Console.WriteLine("ImplementClass.InternalAbstractMethod");
        }
        public new void MethodToBeCalled() {
            AbstractMethod();
        }
    }
