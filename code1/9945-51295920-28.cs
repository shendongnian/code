    namespace Typedef {
    
      [JsonConverter(typeof(JsonCompositionConverter))]
      public abstract class Composer<TDerived, T> : IEquatable<TDerived> where TDerived : Composer<TDerived, T> {
        protected Composer(T composed) { this.Composed = composed; }
        protected Composer(TDerived d) { this.Composed = d.Composed; }
    
        protected T Composed { get; }
    
        public override string ToString() => Composed.ToString();
        public override int GetHashCode() => HashCode.Combine(Composed);
        public override bool Equals(object obj) => obj is Composer<TDerived, T> o && Composed.Equals(o.Composed); 
        public bool Equals(TDerived o) => object.Equals(this, o);
      }
    
      class JsonCompositionConverter : JsonConverter {
        static FieldInfo GetCompositorField(Type t) {
          var fields = t.BaseType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);
          if (fields.Length!=1) throw new JsonSerializationException();
          return fields[0];
        }
    
        public override bool CanConvert(Type t) {
          var fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);
          return fields.Length == 1;
        }
    
        // assumes Compositor<T> has either a constructor accepting T or an empty constructor
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
          while (reader.TokenType == JsonToken.Comment && reader.Read()) { };
          if (reader.TokenType == JsonToken.Null) return null; 
          var compositorField = GetCompositorField(objectType);
          var compositorType = compositorField.FieldType;
          var compositorValue = serializer.Deserialize(reader, compositorType);
          var ctorT = objectType.GetConstructor(new Type[] { compositorType });
          if (!(ctorT is null)) return Activator.CreateInstance(objectType, compositorValue);
          var ctorEmpty = objectType.GetConstructor(new Type[] { });
          if (ctorEmpty is null) throw new JsonSerializationException();
          var res = Activator.CreateInstance(objectType);
          compositorField.SetValue(res, compositorValue);
          return res;
        }
    
        public override void WriteJson(JsonWriter writer, object o, JsonSerializer serializer) {
          var compositorField = GetCompositorField(o.GetType());
          var value = compositorField.GetValue(o);
          serializer.Serialize(writer, value);
        }
      }
    
    }
