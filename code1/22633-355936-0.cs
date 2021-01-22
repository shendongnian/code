        public static Type[] GetTypesImplementingGenericInterface(Type interfaceType, bool includeAbstractTypes, bool includeInterfaceTypes)
        {
            // Use linq to find types that implement the supplied interface.
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().ToList()
                                        .SelectMany(s => s.GetTypes())
                                        .Where(p => p.IsAbstract == includeAbstractTypes
                                               && p.IsInterface == includeInterfaceTypes
                                               && p.GetInterfaces().Any(i=>i.FullName != null && i.FullName.Contains(interfaceType.FullName))
                                               );
            //var implementingTypes = from type in allTypes
            //                        from intf in type.GetInterfaces().ToList()
            //                        where intf.FullName != null && intf.FullName.Contains(interfaceType.FullName)
            //                        select type;
            //return implementingTypes.ToArray<Type>();
            return allTypes.ToArray();
        }
