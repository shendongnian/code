    public interface ISecurityService { }
    public interface ISecurityRepository { }
    public class SecurityService : ISecurityService
    {
        public SecurityService(ISecurityRepository repository)
        {
            Console.WriteLine("SecurityService created");
            Console.WriteLine("Repository is " + repository);
        }
        public override string ToString()
        {
            return "A SecurityService";
        }
    }
    public class SecurityRepository : ISecurityRepository
    {
        public SecurityRepository()
        {
            Console.WriteLine("SecurityRepository created");
        }
        public override string ToString()
        {
            return "A SecurityRepository";
        }
    }
    public class MyClassThatNeedsSecurity
    {
        public MyClassThatNeedsSecurity(ISecurityService security)
        {
            Console.WriteLine("My class has security: " + security);
        }
    }
    class Program
    {
        static void Main()
        {
            using (IUnityContainer container = new UnityContainer())
            {
                container.RegisterType<ISecurityRepository, SecurityRepository>()
                         .RegisterType<ISecurityService, SecurityService>();
                MyClassThatNeedsSecurity myClass =
                    container.Resolve<MyClassThatNeedsSecurity>();
            }
        }
    }
