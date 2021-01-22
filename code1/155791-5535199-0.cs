	public class CustomDataContractSurrogate : IDataContractSurrogate
		{
			public CustomDataContractSurrogate()
			{
			}
			public Type GetDataContractType(Type type)
			{
				if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(IList<>)))
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
