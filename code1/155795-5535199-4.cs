	public class CustomDataContractSurrogate : IDataContractSurrogate
	{
		// The only function you should care about here. The rest don't do anything, just default behavior.
		public Type GetDataContractType(Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(ICollection<>)))
			{
				return (typeof(List<>).MakeGenericType(type.GetGenericArguments().Single()));
			}
			return type;
		}
		public object GetObjectToSerialize(object obj, Type targetType)
		{
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
