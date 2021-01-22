    namespace Something
    {
        public sealed class OuterClass
        {
            private AbstractInnerClass inner;
            public OuterClass(AbstractInnerClass inner)
            {
                this.inner = inner;
            }
            public void MethodToBeCalled()
            {
                MustBeCalled();
                inner.CalledByOuter();
            }
            public void MustBeCalled()
            {
                //this must be called when AbstractMethod is invoked
                System.Console.WriteLine("OuterClass.MustBeCalled");
            }
        }
        public abstract class AbstractInnerClass
        {
            internal void CalledByOuter()
            {
                AbstractMethod();
            }
            protected abstract void AbstractMethod();
        }
    }
    public class ImplementInnerClass : Something.AbstractInnerClass
    {
        protected override void AbstractMethod()
        {
            //when called, base.MustBeCalled() must be called.
            //how can i enforce this?
            System.Console.WriteLine("ImplementInnerClass.AbstractMethod");
        }
        public new void CalledByOuter()
        {
            System.Console.WriteLine("doesn't work");
        }
    }
