    public class Base {
        public void Api() {
           InternalUtilityMethod();
        }
        protected virtual void InternalUtilityMethod() {
           Console.WriteLine("do Base work");
        }
    }
    
    public class Derived : Base {
        protected override void InternalUtilityMethod() {
           Console.WriteLine("do Derived work");
        } 
    }
