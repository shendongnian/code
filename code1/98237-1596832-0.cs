    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(MyClass);
            object obj = Activator.CreateInstance(type);
            Type[] interfaces = obj.GetType().GetInterfaces();
            var m_Client = (UserControl)obj;          
            IFrameworkClient fc = (IFrameworkClient)obj;
        }
    }
    public interface IFrameworkClient { }
    public class UserControl { }
    public class MyClass : UserControl, IFrameworkClient { }
