    public class Base {
        public virtual void TheVirtualFunction() {
            Console.WriteLine($"Base Class Implemenation of Virtual Function from type {GetType().Name}");
        }
        public void NonVirtualFuction() {
            Console.WriteLine($"The non-Virtual Function - Calling Vitual function now from type {GetType().Name}");
            TheVirtualFunction();
        }
    }
    public class Sub  : Base {
        private bool _isCallingAgain = false;
        public override void TheVirtualFunction() {
            Console.WriteLine($"Sub Class Implemenation of Virtual Function from type {GetType().Name}");
            switch (this) {
                case Sub s:
                    if (_isCallingAgain) {
                        Console.WriteLine($"Skipping because v-func called twice from type {GetType().Name}");
                        return;
                    }
                    _isCallingAgain = true;
                    Console.WriteLine($"This pass through the virtual function does something (from type {GetType().Name})");
                    NonVirtualFuction();
                    _isCallingAgain = false;
                    break;
                default:        //if it's not a Sub, then it must be a base
                    NonVirtualFuction();
                    break;
            }
        }
    }
