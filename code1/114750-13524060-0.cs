	[Serializable]
	public class McRealObjectHelper : IObjectReference, ISerializable 
	{
		Object m_realObject;
		virtual object getObject(McObjectId id)
		{
			return id.GetObject();
		}
		public McRealObjectHelper(SerializationInfo info, StreamingContext context)
		{
			McObjectId id = (McObjectId)info.GetValue("ID", typeof(McObjectId));
			m_realObject = getObject(id);
			if(m_realObject == null)
				return;
			Type t = m_realObject.GetType();
			MemberInfo[] members = FormatterServices.GetSerializableMembers(t, context);
			List<MemberInfo> deserializeMembers = new List<MemberInfo>(members.Length);
			List<object> data = new List<object>(members.Length);
			foreach(MemberInfo mi in members)
			{
				Type dataType = null;
				if(mi.MemberType == MemberTypes.Field)
				{
					FieldInfo fi = mi as FieldInfo;
					dataType = fi.FieldType;
				} else if(mi.MemberType == MemberTypes.Property){
					PropertyInfo pi = mi as PropertyInfo;
					dataType = pi.PropertyType;
				}
				try
				{
					if(dataType != null){
						data.Add(info.GetValue(mi.Name, dataType));
						deserializeMembers.Add(mi);
					}
				}
				catch (SerializationException)
				{
					//some fiels are missing, new version, skip this fields
				}
			}
			FormatterServices.PopulateObjectMembers(m_realObject, deserializeMembers.ToArray(), data.ToArray());
		}
		public object GetRealObject( StreamingContext context )
		{
			return m_realObject;
		}
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
		}
	}
	public class McRealObjectBinder: SerializationBinder
	{
		String assemVer;
		String typeVer;
		public McRealObjectBinder(String asmName, String typeName)
		{
			assemVer = asmName;
			typeVer = typeName;
		}
		public override Type BindToType( String assemblyName, String typeName ) 
		{
			Type typeToDeserialize = null;
			if ( assemblyName.Equals( assemVer ) && typeName.Equals( typeVer ) )
			{
				return typeof(McRealObjectHelper);
			}
			typeToDeserialize = Type.GetType( String.Format(  "{0}, {1}", typeName, assemblyName ) );
			return typeToDeserialize;
		}
	}
