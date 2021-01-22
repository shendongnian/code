`
using System;
using System.Reflection;
namespace Mik.Singleton
{
    class Program
    {
        static void Main()
        {
            //You can not create an instance of class directly
            //Singleton1 singleton1 = new Singleton1();
            Singleton1 singleton1 = Singleton1.Instance;
            Singleton2 singleton2 = Singleton2.Instance;
            Console.WriteLine(singleton1.Singleton1Text);
            Console.WriteLine(singleton2.Singleton2Text);
            Console.ReadLine();
        }
    }
    public class SingletonBase<T> where T : class
    {
        #region Singleton implementation
        private static readonly object lockObj = new object();
        private static T _instance;
        protected SingletonBase() { }
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObj)
                    {
                        if (_instance == null)
                            _instance = CreateInstance();
                    }
                }
                return _instance;
            }
        }
        private static T CreateInstance()
        {
            ConstructorInfo constructor = typeof(T).GetConstructor(
                            BindingFlags.Instance | BindingFlags.NonPublic,
                            null, new Type[0],
                            new ParameterModifier[0]);
            if (constructor == null)
                throw new Exception(
                    $"Target type is missing private or protected no-args constructor: {typeof(T).FullName}");
            try
            {
                T instance = constructor.Invoke(new object[0]) as T;
                return instance;
            }
            catch (Exception e)
            {
                throw new Exception(
                    "Failed to create target: type=" + typeof(T).FullName, e);
            }
        }
        #endregion Singleton implementation
    }
    public class Singleton1 : SingletonBase<Singleton1>
    {
        private Singleton1() { }
        public string Singleton1Text { get; } = "Singleton1Text value";
    }
    public class Singleton2 : SingletonBase<Singleton2>
    {
        private Singleton2() { }
        public string Singleton2Text { get; } = "Singleton2Text value";
    }
}
`
