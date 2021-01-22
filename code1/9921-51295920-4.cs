	// WrapperClass is a proxy for asnother class T which it composes in it's Value property
	// it forwards Equals, ==, !=, GetHashCode(), ToString() to Value and serialize to Json via Value
	// when inheriting you still need to define ==, !=, and Equals(Derived) to call base
    
	[JsonConverter(typeof(WrapperClassConverter))]
	public abstract class WrapperClass<T> {
		[JsonConstructor]
		protected WrapperClass(T value) => Value = value;
		public readonly T Value;
		public override bool Equals(object obj) { var o = obj as WrapperClass<T>; return o is null ? false : Value.Equals(o.Value); }
		public bool Equals(WrapperClass<T> o) => object.Equals(this, o);
		public static bool operator ==(WrapperClass<T> o1, WrapperClass<T> o2) => object.Equals(o1, o2);
		public static bool operator !=(WrapperClass<T> o1, WrapperClass<T> o2) => !object.Equals(o1, o2);
		public override int GetHashCode() => IsNull() ? 0 : Value.GetHashCode();
		public override string ToString() => IsNull() ? string.Empty : Value.ToString();
		protected bool IsNull() {
			var nullable = Nullable.GetUnderlyingType(typeof(T)) != null;
			return nullable ? EqualityComparer<T>.Default.Equals(Value, default) : false;
		}
	}
	class WrapperClassConverter : JsonConverter {
		static Type GetValueCollectionType(Type t) {
			while (t != null) { if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(WrapperClass<>)) return t; t = t.BaseType; }
			return null;
		}
		public override bool CanConvert(Type objectType) => GetValueCollectionType(objectType)?.GetGenericArguments()[0] != null;
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			while (reader.TokenType == JsonToken.Comment && reader.Read()) { };
			// You need to decide whether a null JSON token results in a null LikeType<T> or an allocated LikeType<T> with a null Value.
			if (reader.TokenType == JsonToken.Null) return null;
			var valueType = GetValueCollectionType(objectType)?.GetGenericArguments()[0]; 
			var value = serializer.Deserialize(reader, valueType);
			// Here we assume that every subclass of LikeType<T> has a constructor with a single argument, of type T.
			var res = Activator.CreateInstance(objectType, value);
			return res;
		}
		public override void WriteJson(JsonWriter writer, object o, JsonSerializer serializer) {
			var value = GetValueCollectionType(o.GetType())?.GetField("Value", BindingFlags.Instance | BindingFlags.Public)?.GetValue(o);
			serializer.Serialize(writer, value);
		}
	}
