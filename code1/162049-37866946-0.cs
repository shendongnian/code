    public static class TypeExt
    {
      // roundtrip json serialization to enable access to dynamic members and properties originating from another assembly
      public static T JClone<T>( this T source ) { return JsonConvert.DeserializeObject<T>( JsonConvert.SerializeObject( source ) ); }
    }
