    //The abstract singleton
    public abstract class Singleton<T> where T : class
    {
        private static readonly Lazy<T> instance = new Lazy<T>( CreateInstance, true );
        public static T Instance => instance.Value;
        private static T CreateInstance()
        {
            return (T)Activator.CreateInstance( typeof(T), true);
        }
    }
    //This is the usage for any class, that should be a singleton
    public class MyClass : Singleton<MyClass>
    {
        private MyClass()
        {
            //Code...
        }
        //Code...
    }
    //Example usage of the Singleton
    class Program
    {
        static void Main(string[] args)
        {
            MyClass clazz = MyClass.Instance;
        }
    }
