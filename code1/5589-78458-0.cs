    // Disposal Helper Functions
    public static class Disposing
    {
        // Executes IDisposable.Dispose() if it exists.
        public static void DisposeSuperclass(object o)
        {
            Type baseType = o.GetType().BaseType;
            bool superclassIsDisposable = typeof(IDisposable).IsAssignableFrom(baseType);
            if (superclassIsDisposable)
            {
                System.Reflection.MethodInfo baseDispose = baseType.GetMethod("Dispose", new Type[] { });
                baseDispose.Invoke(o, null);
            }
        }
    }
    class classA: IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposing A");
        }
    }
    class classB : classA, IDisposable
    {
    }
    class classC : classB, IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposing C");
            Disposing.DisposeSuperclass(this);
        }
    }
