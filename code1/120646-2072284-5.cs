    namespace MyCompany.MyProduct
    {
        using MyCompany.MyProduct.MyComponent;
        using System.Reflection;
        using System.Security.Policy;
        public class ComponentHost
        {
            public void LoadComponents()
            {
                Assembly implementation = LoadImplementationAssembly();
                /* The implementation assembly path might be loaded from an XML or
                 * similar configuration file
                 */
                Type objectType = implementation.GetType("MyCompany.MyProduct.MyComponent.MyObject");
                Type contentType = implementation.GetType("MyCompany.MyProduct.MyComponent.MyContent");
                /* THIS assembly only works with IMyContentInterface (not generic),
                 * but inside the implementation assembly, you can use the generic
                 * type since you can reference generic type parameter in the source.
                 */
                IMyContentInterface content = (IMyContentInterface)Activator.CreateInstance(contentType);
            }
            private Assembly LoadImplementationAssembly()
            {
                /* The implementation assembly path might be loaded from an XML or
                 * similar configuration file
                 */
                string assemblyPath = "MyCompany.MyProduct.MyComponent.Implementation.dll";
                return Assembly.LoadFile(assemblyPath);
            }
        }
    }
