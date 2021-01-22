    public abstract class GenericFactory<T> where T : MyAbstractType
    {
        public static T GetInstance()
        {
            return (T)Activator.CreateInstance(typeof(T), true);
        }
    }
