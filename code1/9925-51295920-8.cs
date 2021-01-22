	// Composition is a proxy for asnother class T which it composes in it's Value property
	// it forwards Equals, ==, !=, GetHashCode(), ToString() to Value and serialize to Json via Value
	// when inheriting you still need to define ==, !=, and Equals(Derived) to call base
	[JsonConverter(typeof(CompositionConverter))]
	public abstract class Composition<T> {
		[JsonConstructor]
		protected Composition(T value) => Value = value;
		public readonly T Value;
		public override bool Equals(object obj) { var o = obj as Composition<T>; return o is null ? false : Value.Equals(o.Value); }
		public override int GetHashCode() => IsNull() ? 0 : Value.GetHashCode();
		public override string ToString() => IsNull() ? string.Empty : Value.ToString();
		protected bool IsNull() => (Nullable.GetUnderlyingType(typeof(T)) != null) ? EqualityComparer<T>.Default.Equals(Value, default) : false;
	}
	class CompositionConverter : JsonConverter {
		static Type GetValueCollectionType(Type t) {
			while (t != null) { if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Composition<>)) return t; t = t.BaseType; }
			return null;
		}
		private T Cast<T>(object input) => (T)input;
		public override bool CanConvert(Type objectType) => GetValueCollectionType(objectType)?.GetGenericArguments()[0] != null;
		// assumes Compositor<T> has either a constructor accepting T or an empty constructor
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			while (reader.TokenType == JsonToken.Comment && reader.Read()) { };
			if (reader.TokenType == JsonToken.Null) return null; // decide whether a null JSON token results in a null Composition<T> or an allocated LikeType<T> with a null Value.
			var valueType = GetValueCollectionType(objectType).GetGenericArguments()[0];
			var value = serializer.Deserialize(reader, valueType);
			var ctorT = objectType.GetConstructor(new Type[] { valueType });
			if (!(ctorT is null)) return Activator.CreateInstance(objectType, value);
			var ctorEmpty = objectType.GetConstructor(new Type[] { });
			if (ctorEmpty is null) throw new JsonSerializationException();
			var res = Activator.CreateInstance(objectType);
			objectType.GetField("Value", BindingFlags.Instance | BindingFlags.Public).SetValue(res, value);
			return res;
		}
		public override void WriteJson(JsonWriter writer, object o, JsonSerializer serializer) {
			var value = GetValueCollectionType(o.GetType()).GetField("Value", BindingFlags.Instance | BindingFlags.Public).GetValue(o);
			serializer.Serialize(writer, value);
		}
	}
