    #region Using
    
    using System;
    using System.Linq;
    using System.Diagnostics;
    using System.Reflection;
    using System.Reflection.Emit;
    using LVK.Collections;
    
    #endregion
    
    namespace LVK.IoC
    {
        /// <summary>
        /// This class implements a service wrapper that can wrap multiple services into a single multicast
        /// service, that will in turn dispatch all method calls down into all the underlying services.
        /// </summary>
        /// <remarks>
        /// This code is heavily influenced and copied from Marc Gravell's implementation which he
        /// posted on Stack Overflow here: http://stackoverflow.com/questions/847809
        /// </remarks>
        public static class MulticastService
        {
            /// <summary>
            /// Wrap the specified services in a single multicast service object.
            /// </summary>
            /// <typeparam name="TService">
            /// The type of service to implement a multicast service for.
            /// </typeparam>
            /// <param name="services">
            /// The underlying service objects to multicast all method calls to.
            /// </param>
            /// <returns>
            /// The multicast service instance.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// <para><paramref name="services"/> is <c>null</c>.</para>
            /// <para>- or -</para>
            /// <para><paramref name="services"/> contains a <c>null</c> reference.</para>
            /// </exception>
            /// <exception cref="ArgumentException">
            /// <para><typeparamref name="TService"/> is not an interface type.</para>
            /// </exception>
            public static TService Wrap<TService>(params TService[] services)
                where TService: class
            {
                return (TService)Wrap(typeof(TService), (Object[])services);
            }
    
            /// <summary>
            /// Wrap the specified services in a single multicast service object.
            /// </summary>
            /// <param name="serviceInterfaceType">
            /// The <see cref="Type"/> object for the service interface to implement a multicast service for.
            /// </param>
            /// <param name="services">
            /// The underlying service objects to multicast all method calls to.
            /// </param>
            /// <returns>
            /// The multicast service instance.
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// <para><paramref name="serviceInterfaceType"/> is <c>null</c>.</para>
            /// <para>- or -</para>
            /// <para><paramref name="services"/> is <c>null</c>.</para>
            /// <para>- or -</para>
            /// <para><paramref name="services"/> contains a <c>null</c> reference.</para>
            /// </exception>
            /// <exception cref="ArgumentException">
            /// <para><typeparamref name="TService"/> is not an interface type.</para>
            /// </exception>
            /// <exception cref="InvalidOperationException">
            /// <para>One or more of the service objects in <paramref name="services"/> does not implement
            /// the <paramref name="serviceInterfaceType"/> interface.</para>
            /// </exception>
            public static Object Wrap(Type serviceInterfaceType, params Object[] services)
            {
                #region Parameter Validation
    
                if (Object.ReferenceEquals(null, serviceInterfaceType))
                    throw new ArgumentNullException("serviceInterfaceType");
                if (!serviceInterfaceType.IsInterface)
                    throw new ArgumentException("serviceInterfaceType");
                if (Object.ReferenceEquals(null, services) || services.Length == 0)
                    throw new ArgumentNullException("services");
                foreach (var service in services)
                {
                    if (Object.ReferenceEquals(null, service))
                        throw new ArgumentNullException("services");
                    if (!serviceInterfaceType.IsAssignableFrom(service.GetType()))
                        throw new InvalidOperationException("One of the specified services does not implement the specified service interface");
                }
    
                #endregion
    
                if (services.Length == 1)
                    return services[0];
    
                AssemblyName assemblyName = new AssemblyName(String.Format("tmp_{0}", serviceInterfaceType.FullName));
                String moduleName = String.Format("{0}.dll", assemblyName.Name);
                String ns = serviceInterfaceType.Namespace;
                if (!String.IsNullOrEmpty(ns))
                    ns += ".";
    
                var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName,
                    AssemblyBuilderAccess.RunAndSave);
                var module = assembly.DefineDynamicModule(moduleName, false);
                var type = module.DefineType(String.Format("{0}Multicast_{1}", ns, serviceInterfaceType.Name),
                    TypeAttributes.Class |
                    TypeAttributes.AnsiClass |
                    TypeAttributes.Sealed |
                    TypeAttributes.NotPublic);
                type.AddInterfaceImplementation(serviceInterfaceType);
    
                var ar = Array.CreateInstance(serviceInterfaceType, services.Length);
                for (Int32 index = 0; index < services.Length; index++)
                    ar.SetValue(services[index], index);
    
                // Define _Service0..N-1 private service fields
                FieldBuilder[] fields = new FieldBuilder[services.Length];
                var cab = new CustomAttributeBuilder(
                    typeof(DebuggerBrowsableAttribute).GetConstructor(new Type[] { typeof(DebuggerBrowsableState) }),
                    new Object[] { DebuggerBrowsableState.Never });
                for (Int32 index = 0; index < services.Length; index++)
                {
                    fields[index] = type.DefineField(String.Format("_Service{0}", index),
                        serviceInterfaceType, FieldAttributes.Private);
    
                    // Ensure the field don't show up in the debugger tooltips
                    fields[index].SetCustomAttribute(cab);
                }
    
                // Define a simple constructor that takes all our services as arguments
                var ctor = type.DefineConstructor(MethodAttributes.Public,
                    CallingConventions.HasThis,
                    Sequences.Repeat(serviceInterfaceType, services.Length).ToArray());
                var generator = ctor.GetILGenerator();
    
                // Store each service into its own fields
                for (Int32 index = 0; index < services.Length; index++)
                {
                    generator.Emit(OpCodes.Ldarg_0);
                    switch (index)
                    {
                        case 0:
                            generator.Emit(OpCodes.Ldarg_1);
                            break;
    
                        case 1:
                            generator.Emit(OpCodes.Ldarg_2);
                            break;
                        
                        case 2:
                            generator.Emit(OpCodes.Ldarg_3);
                            break;
    
                        default:
                            generator.Emit(OpCodes.Ldarg, index + 1);
                            break;
                    }
                    generator.Emit(OpCodes.Stfld, fields[index]);
                }
                generator.Emit(OpCodes.Ret);
    
                // Implement all the methods of the interface
                foreach (var method in serviceInterfaceType.GetMethods())
                {
                    var args = method.GetParameters();
                    var methodImpl = type.DefineMethod(method.Name,
                        MethodAttributes.Private | MethodAttributes.Virtual,
                        method.ReturnType, (from arg in args select arg.ParameterType).ToArray());
                    type.DefineMethodOverride(methodImpl, method);
    
                    // Generate code to simply call down into each service object
                    // Any return values are discarded, except the last one, which is returned
                    generator = methodImpl.GetILGenerator();
                    for (Int32 index = 0; index < services.Length; index++)
                    {
                        generator.Emit(OpCodes.Ldarg_0);
                        generator.Emit(OpCodes.Ldfld, fields[index]);
                        for (Int32 paramIndex = 0; paramIndex < args.Length; paramIndex++)
                        {
                            switch (paramIndex)
                            {
                                case 0:
                                    generator.Emit(OpCodes.Ldarg_1);
                                    break;
    
                                case 1:
                                    generator.Emit(OpCodes.Ldarg_2);
                                    break;
    
                                case 2:
                                    generator.Emit(OpCodes.Ldarg_3);
                                    break;
    
                                default:
                                    generator.Emit((paramIndex < 255)
                                        ? OpCodes.Ldarg_S
                                        : OpCodes.Ldarg,
                                        paramIndex + 1);
                                    break;
                            }
                            
                        }
                        generator.Emit(OpCodes.Callvirt, method);
                        if (method.ReturnType != typeof(void) && index < services.Length - 1)
                            generator.Emit(OpCodes.Pop); // discard N-1 return values
                    }
                    generator.Emit(OpCodes.Ret);
                }
    
                return Activator.CreateInstance(type.CreateType(), services);
            }
        }
    }
