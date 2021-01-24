    public class EntityBaseConverter : ParameterizedDynamicObjectConverterBase<EntityBase>
    {
        public override EntityBase CreateObject(JObject jObj, Type objectType, JsonSerializer serializer, ICollection<string> usedParameters)
        {
            var entityName = jObj.GetValue("EntityName", StringComparison.OrdinalIgnoreCase);
            if (entityName != null)
            {
                usedParameters.Add(((JProperty)entityName.Parent).Name);
            }
			var entityNameString = entityName == null ? "" : entityName.ToString();
			if (objectType == typeof(EntityBase))
			{
	            return new EntityBase(entityName == null ? "" : entityName.ToString());				
			}
			else
			{
				return (EntityBase)Activator.CreateInstance(objectType, new object [] { entityNameString });
			}			
        }
    }
    public abstract class ParameterizedDynamicObjectConverterBase<T> : JsonConverter where T : DynamicObject
    {
		public override bool CanConvert(Type objectType) { return typeof(T).IsAssignableFrom(objectType); } // Or possibly return objectType == typeof(T);
        public abstract T CreateObject(JObject jObj, Type objectType, JsonSerializer serializer, ICollection<string> usedParameters);
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
			// Logic adapted from JsonSerializerInternalReader.CreateDynamic()
			// https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Serialization/JsonSerializerInternalReader.cs#L1751
			// By James Newton-King https://github.com/JamesNK
			
            var contract = (JsonDynamicContract)serializer.ContractResolver.ResolveContract(objectType);
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jObj = JObject.Load(reader);
            var used = new HashSet<string>();
            var obj = CreateObject(jObj, objectType, serializer, used);
            foreach (var jProperty in jObj.Properties())
            {
                var memberName = jProperty.Name;
                if (used.Contains(memberName))
                    continue;
                // first attempt to find a settable property, otherwise fall back to a dynamic set without type
                JsonProperty property = contract.Properties.GetClosestMatchProperty(memberName);
                if (property != null && property.Writable && !property.Ignored)
                {
                    var propertyValue = jProperty.Value.ToObject(property.PropertyType, serializer);
                    property.ValueProvider.SetValue(obj, propertyValue);
                }
                else
                {
                    object propertyValue;
                    if (jProperty.Value.Type == JTokenType.Null)
                        propertyValue = null;
                    else if (jProperty.Value is JValue)
                        // Primitive
                        propertyValue = ((JValue)jProperty.Value).Value;
                    else
                        propertyValue = jProperty.Value.ToObject<IDynamicMetaObjectProvider>(serializer);
					// Unfortunately the following is not public!
                    // contract.TrySetMember(obj, memberName, propertyValue);
					// So we have to duplicate the logic of what Json.NET has already done.
					CallSiteCache.SetValue(memberName, obj, propertyValue);
                }				
            }
            return obj;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
	internal static class CallSiteCache
	{
		// Adapted from the answer to 
		// https://stackoverflow.com/questions/12057516/c-sharp-dynamicobject-dynamic-properties
		// by jbtule, https://stackoverflow.com/users/637783/jbtule
		// And also
		// https://github.com/mgravell/fast-member/blob/master/FastMember/CallSiteCache.cs
		// by Marc Gravell, https://github.com/mgravell
						
		private static readonly Dictionary<string, CallSite<Func<CallSite, object, object, object>>> setters 
			= new Dictionary<string, CallSite<Func<CallSite, object, object, object>>>();
		
		public static void SetValue(string propertyName, object target, object value)
		{
			CallSite<Func<CallSite, object, object, object>> site;
			
			lock (setters)
			{
				if (!setters.TryGetValue(propertyName, out site))
				{
					var binder = Binder.SetMember(CSharpBinderFlags.None,
						   propertyName, typeof(CallSiteCache),
						   new List<CSharpArgumentInfo>{
								   CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								   CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)});
					setters[propertyName] = site = CallSite<Func<CallSite, object, object, object>>.Create(binder);
				}
			}
			
			site.Target(site, target, value);
		}
	}
