    public interface ICommonServices
    {
        string SomeProperty { get; set; }
        void SomeMethod(string param);
    }
    public static class CommonServiceMethods
    {
        public static void DoSomething(this ICommonServices services, string param)
        {
            services.SomeMethod(services.SomeProperty + ": " + param + " something extra!");
        }
    }
