        public static Type[] GetTypesImplementingGenericInterface(Type interfaceType, bool includeAbstractTypes, bool includeInterfaceTypes)
        {
            // Use linq to find types that implement the supplied interface.
            var implementingTypes = AppDomain.CurrentDomain.GetAssemblies().ToList()
                                        .SelectMany(s => s.GetTypes())
                                        .Where(p => interfaceType.IsAssignableFrom(p)
                                                  && (
                                                         (p.IsAbstract && includeAbstractTypes) 
                                                         || (p.IsInterface && includeInterfaceTypes)
                                                         || (!p.IsAbstract && !p.IsInterface)
                                                     )
                                              );
            return implementingTypes.ToArray<Type>();
        }
