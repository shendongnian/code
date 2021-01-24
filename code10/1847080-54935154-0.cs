    public interface ICommonFunctionality
    {
        void SomethingThatEveryoneCanDo();
        // ... other common functionality
    }
    public interface IAdditionalFunctionality1
    {
        void SomethingThatAFewCanDo();
        // ... other special functionality
    }
    public interface IAdditionalFunctionality2
    {
        void SomethingThatOthersCanDo();
        // ... other special functionality
    }
    public class MyClass : ICommonFunctionality
    {
        static public ICommonFunctionality Create(Type derivedType)
        {
            if (!typeof(ICommonFunctionality).IsAssignableFrom(derivedType)) { throw new ArgumentException(); }
            return derivedType.CreateInstance() as ICommonFunctionality;
        }
        virtual public void SomethingThatEveryoneCanDo() { /* ... */  }
    }
    public class MyClass1 : MyClass, IAdditionalFunctionality1
    {
        public void SomethingThatAFewCanDo() { /* ... */ }
    }
    public class MyClass2 : MyClass, IAdditionalFunctionality1, IAdditionalFunctionality2
    {
        public void SomethingThatAFewCanDo() { /* ... */ }
        public void SomethingThatOthersCanDo() { /* ... */ }
    }
    public class MyClass3 : MyClass, IAdditionalFunctionality2
    {
        public void SomethingThatOthersCanDo() { /* ... */ }
    }
    public static class TypeHelpers
    {
        public static object CreateInstance(this Type type, bool required = true)
        {
            System.Reflection.ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
            if (required && ctor == null) { throw new InvalidOperationException("Missing required constructor."); }
            return ctor?.Invoke(null);
        }
    }
