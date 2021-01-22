            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                bool isIFactory = (from i in type.GetInterfaces()
                                   where i.IsGenericType &&
                                         i.GetGenericTypeDefinition() == typeof(IFactory<>) &&
                                         i.IsAssignableFrom(i.GetGenericArguments()[0])
                                         // this one could be also changed to i.GetGenericArguments()[0] == type
                                         // however, it'll generate an anonymous class, which will show in the outer foreach
                                   select i).Count() == 1;
            }
