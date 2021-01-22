    interface IInterface {
       void Do();
       void Go();
    }
    
    abstract class ClassBase : IInterface {
    
        public virtual void Do() {
             // Default behaviour
        }
        public abstract void Go();  // No default behaviour
    
    }
    
    class ConcreteClass : ClassBase {
    
        public override void Do() {
             // Specialised behaviour
        }
        public override void Go() {
            // ...
        }
    
    }
