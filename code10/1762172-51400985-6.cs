    using System.Configuration;
    using Microsoft.Practices.Unity.Configuration;
    using Unity;
    using UnityExample.Service;
    namespace UnityExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var container = new UnityContainer();
                UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                section.Configure(container, "Service");
                IProductService service = container.Resolve<IProductService>();
            }
        }
    }
