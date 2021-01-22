    public enum InputType {
        Number = 1,
        String = 2,
        Date = 3
    }
    public class BaseClass {
        public BaseClass(InputType t) {
            // Logic
        }
    }
    public class DerivedClass : BaseClass {
        public DerivedClass(int i)
            : base(GetInputType(i)) {
            // Is it possible to set "value" here?
            // Logic
        }
        private static InputType GetInputType(Int32 parameter) {
            // Do something with parameter
            // and return an InputType
            return InputType.Number;
        }
    }
