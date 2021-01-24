services.Configure(MyType, o => { var castObj = (MyType)o; section.Bind(castObj); });
---
    using System;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    namespace WebApplication1
    {
        public static class MyServiceExtensions
        {
            public static IServiceCollection Configure(this IServiceCollection services, Type type, Action<object> configureOptions)
            {
                // Static type that contains the extension method
                var extMethodType = typeof(OptionsServiceCollectionExtensions);
                // Find the overload for Configure<TOptions>(IServiceCollection, Action<TOptions>)
                // This could be more specific to make sure that all type arguments are exactly correct.
                // As it stands, this returns the correct overload but future updates to OptionsServiceCollectionExtensions
                // may add additional overloads which will require this to be updated.
                var genericConfigureMethodInfo = extMethodType.GetMethods()
                    .Where(m => m.IsGenericMethod && m.Name == "Configure")
                    .Select(m => new
                    {
                        Method = m,
                        Params = m.GetParameters(),
                        Args = m.GetGenericArguments() // Generic Type[] (ex [TOptions])
                    })
                    .Where(m => m.Args.Length == 1 && m.Params.Length == 2
                        && m.Params[0].ParameterType == typeof(IServiceCollection))
                    .Select(m => m.Method)
                    .Single();
                var method = genericConfigureMethodInfo.MakeGenericMethod(type);
                // Invoke the method via reflection with our converted Action<objct> delegate
                // Since this is an extension method, it is static and services is passed
                // as the first parameter instead of the target object
                method.Invoke(null, new object[] { services, configureOptions });
                return services;
            }
        }
    }
