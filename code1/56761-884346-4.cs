    using System;
    using System.Reflection;
    
    class Test
    {   
        static void Main()
        {
            Delegate[] delegates = new Delegate[]
            {
                (Action<int>) (x => Console.WriteLine("int={0}", x)),
                (Action<string>) (x => Console.WriteLine("string={0}", x)),
                (Func<int, int>) (x => x + 1)
            };
            
            MethodInfo genericPerformAction = typeof(Test).GetMethod
                                                           ("PerformAction");
            
            foreach (Delegate del in delegates)
            {
                Type t = DiscoverTypeArgument(del, typeof(Action<>));
                if (t == null)
                {
                    // Wrong type (e.g. the Func in the array)
                    continue;
                }
                MethodInfo concreteMethod = genericPerformAction.MakeGenericMethod
                    (new[] { t } );
                concreteMethod.Invoke(null, new object[] { del });
            }
        }
        
        public static void PerformAction<T>(Action<T> action)
        {
            Console.WriteLine("Performing action with type {0}", typeof(T).Name);
            action(default(T));
        }
        
        /// <summary>
        /// Discovers the type argument for an object based on a generic
        /// class which may be somewhere in its class hierarchy. The generic
        /// type must have exactly one type parameter.
        /// </summary>
        /// <returns>
        /// The type argument, or null if the object wasn't in
        /// the right hierarchy.
        /// </returns>
        static Type DiscoverTypeArgument(object o, Type genericType)
        {
            if (o == null || genericType == null)
            {
                throw new ArgumentNullException();
            }
            if (genericType.IsInterface ||
                !genericType.IsGenericTypeDefinition || 
                genericType.GetGenericArguments().Length != 1)
            {
                throw new ArgumentException("Bad type");
            }
            
            Type objectType = o.GetType();
            while (objectType != null)
            {
                if (objectType.IsGenericType &&
                    objectType.GetGenericTypeDefinition() == genericType)
                {
                    return objectType.GetGenericArguments()[0];
                }
                objectType = objectType.BaseType;
            }
            return null;
        }
    }
