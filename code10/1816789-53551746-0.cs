    public class Base {
        public virtual void TheVirtualFunction() {
            Console.WriteLine("Base Class Implemenation of Virtual Function");
            CommonCodeThatMustBeCalledByAllImpementations();
        }
        public void NonVirtualFuction() {
            Console.WriteLine("The non-Virtual Function - Calling Vitual function now");
            TheVirtualFunction();
        }
        protected void CommonCodeThatMustBeCalledByAllImpementations() {
            Console.WriteLine("The common code");
        }
    }
    public class Sub  : Base{
        public override void TheVirtualFunction() {
            Console.WriteLine("Sub Class Implemenation of Virtual Function");
            CommonCodeThatMustBeCalledByAllImpementations();
        }
    }
