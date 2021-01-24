     abstract class A
        {
            public abstract void MyMethod();
        }
    
        class B : A
        {
            public sealed override void MyMethod()
            {
    
            }
        }
    
        class C : B
        {
            public override void MyMethod()
            {
    
            }
        }
