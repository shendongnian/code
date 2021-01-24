    public interface IActivatorWrapper
    {
        object CreateInstance(Type type);
    }
    public class ActivatorWrapper : IActivatorWrapper
    {
        public object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
