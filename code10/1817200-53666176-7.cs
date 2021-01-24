        public static List<MemberInfo> GetSerializableMembers( Type type, BindingFlags bindingFlags )
		{
			List<MemberInfo> list = new List<MemberInfo>();
			FieldInfo[] fields = type.GetFields( bindingFlags );
			foreach ( FieldInfo field in fields )
			{
				if ( IsFieldSerializable( type, field ) == false )
					continue;
				list.Add( field );
			}
			PropertyInfo[] properties = type.GetProperties( bindingFlags );
			foreach ( PropertyInfo property in properties )
			{
				if ( IsPropertySerializable( type, property ) == false )
					continue;
				list.Add( property );
			}
			return list;
		}
        public static bool IsFieldSerializable( Type type, FieldInfo field )
		{
			if ( field.IsInitOnly == true )
				return false;
			if ( field.IsLiteral == true )
				return false;
			if ( field.IsDefined( typeof( CompilerGeneratedAttribute ), false ) == true )
				return false;
			if ( field.IsDefined( typeof( IgnoreAttribute ), false ) == true )
				return false;
			return true;
		}
		public static bool IsPropertySerializable( Type type, PropertyInfo property )
		{
			if ( property.CanRead == false )
				return false;
			if ( property.CanWrite == false )
				return false;
			if ( property.GetIndexParameters().Length != 0 )
				return false;
			if ( property.GetMethod.IsVirtual && property.GetMethod.GetBaseDefinition().DeclaringType != type )
				return false;
			if ( property.IsDefined( typeof( IgnoreAttribute ), false ) == true )
				return false;
			return true;
		}
