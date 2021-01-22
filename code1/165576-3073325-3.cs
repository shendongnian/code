    public class MyObject : IServices
    {
        public string PublicProperty { get; private set; }
        string IServices.SomeProperty { get; set; }
        void IServices.SomeMethod(string param)
        {
            //Do something...
        }
    }
    public interface IPublicServices
    {
        string PublicProperty { get; }
    }
    internal interface IServices : IPublicServices
    {
        string SomeProperty { get; set; }
        void SomeMethod(string param);
    }
    internal static class ServiceMethods
    {
        public static void DoSomething(this IServices services, string param)
        {
            services.SomeMethod(services.SomeProperty + ": " + param + " something extra!");
        }
    }
