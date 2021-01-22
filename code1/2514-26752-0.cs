    public static List<Type> GetSubclassesOf(this Type type, bool excludeSystemTypes)
    {
        List<Type> list = new List<Type>();
        IEnumerator enumerator = Thread.GetDomain().GetAssemblies().GetEnumerator();
        while (enumerator.MoveNext())
        {
            try
            {
                Type[] types = ((Assembly) enumerator.Current).GetTypes();
                if (!excludeSystemTypes || (excludeSystemTypes && !((Assembly) enumerator.Current).FullName.StartsWith("System.")))
                {
                    IEnumerator enumerator2 = types.GetEnumerator();
                    while (enumerator2.MoveNext())
                    {
                        Type current = (Type) enumerator2.Current;
                        if (type.IsInterface)
                        {
                            if (current.GetInterface(type.FullName) != null)
                            {
                                list.Add(current);
                            }
                        }
                        else if (current.IsSubclassOf(type))
                        {
                            list.Add(current);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        return list;
    }
