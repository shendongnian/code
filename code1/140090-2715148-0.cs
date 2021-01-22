    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Routing;
    
    namespace MyCompany.Web.Mvc
    {
        /// <summary>
        /// Provides helpful utilities for performing area registration, where <see cref="AreaRegistration.RegisterAllAreas()"/> may not suffice.
        /// </summary>
        public static class AreaRegistrationUtil
        {
            /// <summary>
            /// Registers all areas found in the assembly containing the given type.
            /// </summary>
            /// <typeparam name="T">A type that derives from <see cref="AreaRegistration"/> and has a default constructor.</typeparam>
            public static void RegisterAreasForAssemblyOf<T>()
                where T : AreaRegistration, new()
            {
                RegisterAreasForAssemblyOf<T>(null);
            }
    
            /// <summary>
            /// Registers all areas found in the assembly containing the given type.
            /// </summary>
            /// <typeparam name="T">A type that derives from <see cref="AreaRegistration"/> and has a default constructor.</typeparam>
            /// <param name="state">An object containing state that will be passed to the area registration.</param>
            public static void RegisterAreasForAssemblyOf<T>(object state)
                where T : AreaRegistration, new()
            {
                RegisterAreasForAssemblies(state, typeof (T).Assembly);
            }
    
            /// <summary>
            /// Registers all areas found in the given assemblies.
            /// </summary>
            /// <param name="assemblies"><see cref="Assembly"/> objects containing the prospective area registrations.</param>
            public static void RegisterAreasForAssemblies(params Assembly[] assemblies)
            {
                RegisterAreasForAssemblies(null, assemblies);
            }
    
            /// <summary>
            /// Registers all areas found in the given assemblies.
            /// </summary>
            /// <param name="state">An object containing state that will be passed to the area registration.</param>
            /// <param name="assemblies"><see cref="Assembly"/> objects containing the prospective area registrations.</param>
            public static void RegisterAreasForAssemblies(object state, params Assembly[] assemblies)
            {
                foreach (Type type in
                    from assembly in assemblies
                    from type in assembly.GetTypes()
                    where IsAreaRegistrationType(type)
                    select type)
                {
                    RegisterArea((AreaRegistration) Activator.CreateInstance(type), state);
                }
            }
    
            /// <summary>
            /// Performs area registration using the specified type.
            /// </summary>
            /// <typeparam name="T">A type that derives from <see cref="AreaRegistration"/> and has a default constructor.</typeparam>
            public static void RegisterArea<T>()
                where T : AreaRegistration, new()
            {
                RegisterArea<T>(null);
            }
    
            /// <summary>
            /// Performs area registration using the specified type.
            /// </summary>
            /// <typeparam name="T">A type that derives from <see cref="AreaRegistration"/> and has a default constructor.</typeparam>
            /// <param name="state">An object containing state that will be passed to the area registration.</param>
            public static void RegisterArea<T>(object state)
                where T : AreaRegistration, new()
            {
                var registration = Activator.CreateInstance<T>();
                RegisterArea(registration, state);
            }
    
            private static void RegisterArea(AreaRegistration registration, object state)
            {
                var context = new AreaRegistrationContext(registration.AreaName, RouteTable.Routes, state);
                string ns = registration.GetType().Namespace;
    
                if (ns != null) context.Namespaces.Add(string.Format("{0}.*", ns));
    
                registration.RegisterArea(context);
            }
    
            /// <summary>
            /// Returns whether or not the specified type is assignable to <see cref="AreaRegistration"/>.
            /// </summary>
            /// <param name="type">A <see cref="Type"/>.</param>
            /// <returns>True if the specified type is assignable to <see cref="AreaRegistration"/>; otherwise, false.</returns>
            private static bool IsAreaRegistrationType(Type type)
            {
                return (typeof (AreaRegistration).IsAssignableFrom(type) && (type.GetConstructor(Type.EmptyTypes) != null));
            }
        }
    }
