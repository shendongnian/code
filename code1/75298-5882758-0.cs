     public class HibernateDataContractSurrogate : IDataContractSurrogate
    {
        public HibernateDataContractSurrogate()
        {
        }
        public Type GetDataContractType(Type type)
        {
            // Serialize proxies as the base type
            if (typeof(INHibernateProxy).IsAssignableFrom(type))
            {
                type = type.GetType().BaseType;
            }
            // Serialize persistent collections as the collection interface type
            if (typeof(IPersistentCollection).IsAssignableFrom(type))
            {
                foreach (Type collInterface in type.GetInterfaces())
                {
                    if (collInterface.IsGenericType)
                    {
                        type = collInterface;
                        break;
                    }
                    else if (!collInterface.Equals(typeof(IPersistentCollection)))
                    {
                        type = collInterface;
                    }
                }
            }
            return type;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            // Serialize proxies as the base type
            if (obj is INHibernateProxy)
            {
                // Getting the implementation of the proxy forces an initialization of the proxied object (if not yet initialized)
                try
                {
                    var newobject = ((INHibernateProxy)obj).HibernateLazyInitializer.GetImplementation();
                    obj = newobject;
                }
                catch (Exception)
                {
                   // Type test = NHibernateProxyHelper.GetClassWithoutInitializingProxy(obj);
                    obj = null;
                }
            }
            // Serialize persistent collections as the collection interface type
            if (obj is IPersistentCollection)
            {
                IPersistentCollection persistentCollection = (IPersistentCollection)obj;
                persistentCollection.ForceInitialization();
                //obj = persistentCollection.Entries(); // This returns the "wrapped" collection
                obj = persistentCollection.Entries(null); // This returns the "wrapped" collection
            }
            return obj;
        }
        
       
        public object GetDeserializedObject(object obj, Type targetType)
        {
            return obj;
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }
        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return typeDeclaration;
        }
    }
