    public class IAPISessionFactory
    {
        public static IAPISession<T> GetInstance() where T : IAPISession
        {
            if(typeof(T) == typeof(ConcreteSession)
                return ConcreteSession.GetInstance();
        }
    }
