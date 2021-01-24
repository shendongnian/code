    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Castle.Core;
    using Castle.DynamicProxy;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using ConsoleApplication1;
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var container = new WindsorContainer();
                container.Register(Castle.MicroKernel.Registration.Component.For<AuthorizedUserData>().LifestyleSingleton());
                container.Register(
                   Castle.MicroKernel.Registration
                    .Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn<IUserData>()
                    .WithServiceAllInterfaces().Configure(
                                    x =>
                                    x.Interceptors<AuthorizedUserData>()));
                var user = container.Resolve<IUserData>();
                user.ByName("Rudresh");
                Console.ReadLine();
            }
        }
        public interface IUserData
        {
            User GetUser(uint id);
            User ByName(string username);
        }
        public class UserData : IUserData
        {
            public User GetUser(uint id)
            {
                throw new System.NotImplementedException();
            }
            public User ByName(string username)
            {
                throw new System.NotImplementedException();
            }
        }
        public class AuthorizedUserData : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                throw new System.NotImplementedException();
            }
        }
        public class User
        {
        }
    }
