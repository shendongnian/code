    /// <summary>
    /// IDataContractSurrogate to map Enum to int for handling invalid values
    /// </summary>
    public class InvalidEnumContractSurrogate : IDataContractSurrogate
    {
        private HashSet<Type> typelist;
        /// <summary>
        /// Create new Data Contract Surrogate to handle the specified Enum type
        /// </summary>
        /// <param name="type">Enum Type</param>
        public InvalidEnumContractSurrogate(Type type)
        {
            typelist = new HashSet<Type>();
            if (!type.IsEnum) throw new ArgumentException(type.Name + " is not an enum","type");
            typelist.Add(type);
        }
        /// <summary>
        /// Create new Data Contract Surrogate to handle the specified Enum types
        /// </summary>
        /// <param name="types">IEnumerable of Enum Types</param>
        public InvalidEnumContractSurrogate(IEnumerable<Type> types)
        {
            typelist = new HashSet<Type>();
            foreach (var type in types)
            {
                if (!type.IsEnum) throw new ArgumentException(type.Name + " is not an enum", "type");
                typelist.Add(type);
            }
        }
        #region Interface Implementation
        public Type GetDataContractType(Type type)
        {
            //If the provided type is in the list, tell the serializer it is an int
            if (typelist.Contains(type)) return typeof(int);
            return type;
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            //If the type of the object being serialized is in the list, case it to an int
            if (typelist.Contains(obj.GetType())) return (int)obj;
            return obj;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            //If the target type is in the list, convert the value (we are assuming it to be int) to the enum
            if (typelist.Contains(targetType)) return Enum.ToObject(targetType, obj);
            return obj;
        }
        public void GetKnownCustomDataTypes(System.Collections.ObjectModel.Collection<Type> customDataTypes)
        {
            //not used
            return;
        }
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            //Not used
            return null;
        }
        public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
        {
            //not used
            return null;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            //not used
            return null;
        }
        public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
        {
            //not used
            return typeDeclaration;
        }
        #endregion
    }
