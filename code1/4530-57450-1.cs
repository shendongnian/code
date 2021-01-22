    public class GenericFactory<T> where T : MyAbstractType
    {
        public static T GetInstance()
        {
            return Activator.CreateInstance(typeof(T), true);
        }
    }
