		public class DataContractJavaScriptConverter : JavaScriptConverter
		{
			private static readonly List<Type> _supportedTypes = new List<Type>();
			static DataContractJavaScriptConverter()
			{
				foreach (Type type in Assembly.GetExecutingAssembly().DefinedTypes)
				{
					if (Attribute.IsDefined(type, typeof(DataContractAttribute)))
					{
						_supportedTypes.Add(type);
					}
				}
			}
			private bool ConvertEnumToString = false;
			public DataContractJavaScriptConverter() : this(false)
			{
			}
			public DataContractJavaScriptConverter(bool convertEnumToString)
			{
				ConvertEnumToString = convertEnumToString;
			}
			public override IEnumerable<Type> SupportedTypes
			{
				get { return _supportedTypes; }
			}
			public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
			{
				if (Attribute.IsDefined(type, typeof(DataContractAttribute)))
				{
					try
					{
						object instance = Activator.CreateInstance(type);
						IEnumerable<MemberInfo> members = ((IEnumerable<MemberInfo>)type.GetFields())
							.Concat(type.GetProperties().Where(property => property.CanWrite && property.GetIndexParameters().Length == 0))
							.Where((member) => Attribute.IsDefined(member, typeof(DataMemberAttribute)));
						foreach (MemberInfo member in members)
						{
							DataMemberAttribute attribute = (DataMemberAttribute)Attribute.GetCustomAttribute(member, typeof(DataMemberAttribute));
							object value;
							if (dictionary.TryGetValue(attribute.Name, out value) == false)
							{
								if (attribute.IsRequired)
								{
									throw new SerializationException(String.Format("Required DataMember with name {0} not found", attribute.Name));
								}
								continue;
							}
							if (member.MemberType == MemberTypes.Field)
							{
								FieldInfo field = (FieldInfo)member;
								object fieldValue;
								if (ConvertEnumToString && field.FieldType.IsEnum)
								{
									fieldValue = Enum.Parse(field.FieldType, value.ToString());
								}
								else
								{
									fieldValue = serializer.ConvertToType(value, field.FieldType);
								}
								field.SetValue(instance, fieldValue);
							}
							else if (member.MemberType == MemberTypes.Property)
							{
								PropertyInfo property = (PropertyInfo)member;
								object propertyValue;
								if (ConvertEnumToString && property.PropertyType.IsEnum)
								{
									propertyValue = Enum.Parse(property.PropertyType, value.ToString());
								}
								else
								{
									propertyValue = serializer.ConvertToType(value, property.PropertyType);
								}
								property.SetValue(instance, propertyValue);
							}
						}
						return instance;
					}
					catch (Exception)
					{
						return null;
					}
				}
				return null;
			}
			public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				if (obj != null && Attribute.IsDefined(obj.GetType(), typeof(DataContractAttribute)))
				{
					Type type = obj.GetType();
					IEnumerable<MemberInfo> members = ((IEnumerable<MemberInfo>)type.GetFields())
						.Concat(type.GetProperties().Where(property => property.CanRead && property.GetIndexParameters().Length == 0))
						.Where((member) => Attribute.IsDefined(member, typeof(DataMemberAttribute)));
					foreach (MemberInfo member in members)
					{
						DataMemberAttribute attribute = (DataMemberAttribute)Attribute.GetCustomAttribute(member, typeof(DataMemberAttribute));
						object value;
						if (member.MemberType == MemberTypes.Field)
						{
							FieldInfo field = (FieldInfo)member;
							if (ConvertEnumToString && field.FieldType.IsEnum)
							{
								value = field.GetValue(obj).ToString();
							}
							else
							{
								value = field.GetValue(obj);
							}
						}
						else if (member.MemberType == MemberTypes.Property)
						{
							PropertyInfo property = (PropertyInfo)member;
							if (ConvertEnumToString && property.PropertyType.IsEnum)
							{
								value = property.GetValue(obj).ToString();
							}
							else
							{
								value = property.GetValue(obj);
							}
						}
						else
						{
							continue;
						}
						if (dictionary.ContainsKey(attribute.Name))
						{
							throw new SerializationException(String.Format("More than one DataMember found with name {0}", attribute.Name));
						}
						dictionary[attribute.Name] = value;
					}
				}
				return dictionary;
			}
		}
