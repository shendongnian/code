    public abstract class GenericFactory<T> where T : MyAbstractType, new()
    {
        public static T GetInstance()
        {
            return new T;
        }
    }
