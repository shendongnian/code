    public class Sample
    {
        public void MethodWithDelegateConstraint<T>() where T: Delegate
        {
        }
        public void MethodWithEnumConstraint<T>() where T: struct, Enum
        {
        }
    }
