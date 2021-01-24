	class MongoDB_SerializationProvider : BsonSerializationProviderBase
	{
		private static readonly object locker = new object();
		private static Dictionary<Type, MongoDB_StructSerializer> _StructSerializers;
		private static MongoDB_DecimalSerializer _DecimalSerializer;
		static MongoDB_SerializationProvider()
		{
			_StructSerializers = new Dictionary<Type, MongoDB_StructSerializer>();
			_DecimalSerializer = new MongoDB_DecimalSerializer();
		}
		public override IBsonSerializer GetSerializer( Type type, IBsonSerializerRegistry serializerRegistry )
		{
			if ( type == typeof( decimal ) )
			{
				return _DecimalSerializer;
			}
			else if ( Reflection.Info.IsStruct( type ) && type != typeof( ObjectId ) )
			{
				MongoDB_StructSerializer structSerializer = null;
				lock ( locker )
				{
					if ( _StructSerializers.TryGetValue( type, out structSerializer ) == false )
					{
						structSerializer = new MongoDB_StructSerializer( type );
						_StructSerializers.Add( type, structSerializer );
					}
				}
				return structSerializer;
			}
			else
			{
				return null;
			}
		}
	}
