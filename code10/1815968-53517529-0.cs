        public static bool IsContainerType( Type type )
		{
			TypeInfo typeInfo = type.GetTypeInfo();
			if ( typeInfo.IsArray == true )
				return true;
			if ( typeof( System.Collections.IList ).IsAssignableFrom( type ) == true )
				return true;
			if ( typeof( System.Collections.IDictionary ).IsAssignableFrom( type ) == true )
				return true;
			return false;
		}
