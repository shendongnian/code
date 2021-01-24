	public class MongoDB_StructSerializer : IBsonSerializer
	{
		public Type ValueType { get; }
		public MongoDB_StructSerializer( Type valueType )
		{
			ValueType = valueType;
		}
		public void Serialize( BsonSerializationContext context, BsonSerializationArgs args, object value )
		{
			if ( value == null )
			{
				context.Writer.WriteNull();
			}
			else
			{
				List<MemberInfo> members = Reflection.Serialize.GetAllSerializableMembers( ValueType );
				context.Writer.WriteStartDocument();
				foreach( MemberInfo member in members )
				{
					context.Writer.WriteName( member.Name );
					BsonSerializer.Serialize( context.Writer, Reflection.Info.GetMemberType( member ), Reflection.Info.GetMemberValue( member, value ), null, args );
				}
				context.Writer.WriteEndDocument();
			}
		}
		public object Deserialize( BsonDeserializationContext context, BsonDeserializationArgs args )
		{
			BsonType bsonType = context.Reader.GetCurrentBsonType();
			if ( bsonType == BsonType.Null )
			{
				context.Reader.ReadNull();
				return null;
			}
			else
			{
				object obj = Activator.CreateInstance( ValueType );
				context.Reader.ReadStartDocument();
				while ( context.Reader.ReadBsonType() != BsonType.EndOfDocument )
				{
					string name = context.Reader.ReadName();
					FieldInfo field = ValueType.GetField( name );
					if ( field != null )
					{
						object value = BsonSerializer.Deserialize( context.Reader, field.FieldType );
						field.SetValue( obj, value );
					}
					PropertyInfo prop = ValueType.GetProperty( name );
					if ( prop != null )
					{
						object value = BsonSerializer.Deserialize( context.Reader, prop.PropertyType );
						prop.SetValue( obj, value, null );
					}
				}
				context.Reader.ReadEndDocument();
				return obj;
			}
		}
	}
