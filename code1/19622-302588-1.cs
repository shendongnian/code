            public static IEnumerable<T> GetInstancesOfImplementingTypes<T>()
            {
                AppDomain app = AppDomain.CurrentDomain;
                Assembly[] ass = app.GetAssemblies();
                Type[] types;
                Type targetType = typeof(T);
    
                foreach (Assembly a in ass)
                {
                    types = a.GetTypes();
                    foreach (Type t in types)
                    {
                        if (t.IsInterface) continue;
                        if (t.IsAbstract) continue;
                        foreach (Type iface in t.GetInterfaces())
                        {
                            if (!iface.Equals(targetType)) continue;
                            yield return (T) Activator.CreateInstance(t);
                            break;
                        }
                    }
                }
            }
