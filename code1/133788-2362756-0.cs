    public static List<Type> FindAllDerivedTypes<T>()
                    {
                        var derivedType = typeof(T);
                        var assembly = Assembly.GetAssembly(derivedType);
                        return assembly
                            .GetTypes()
                            .Where(t => 
                                t != derivedType &&
                                derivedType.IsAssignableFrom(t)
                                ).ToList();
            
                    } 
