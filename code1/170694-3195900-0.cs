    public abstract class BaseClass { }
    public interface IMyClass { }
    internal interface IMyClassImpl { }
    public class MyClass : BaseClass, IMyClass, IMyClassImpl
    {
        //IMyClassImpl members should be implemented explicitly, so they are inaccessible to outside clients.
    }
    public static class MyClassExtensions
    {
        public static void HelperMethod(this IMyClass instance)
        {
            //Do stuff...
            //Can access internal implementation as necessary
            var impl = (IMyClassImpl)instance;
            impl.InternalHelperMethod();
        }
        internal static void InternalHelperMethod(this IMyClassImpl instance)
        {
            
        }
    }
