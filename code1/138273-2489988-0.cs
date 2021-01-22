    private static T DeepClone<T>( this T source, Dictionary<object, object> map )
        where T : class, new()
    {
        Type type = source.GetType();
        IList<FieldInfo> fields = type.Fields( Flags.StaticInstanceAnyVisibility );
        var clone = type.CreateInstance() as T;
        map = map ?? new Dictionary<object, object>();
        map[ source ] = clone;
        object[] values = fields.Select( f => GetValue( f, source, map ) ).ToArray();
        for( int i = 0; i < fields.Count; i++ )
        {
            fields[ i ].Set( clone, values[ i ] );
        }
        return clone;
    }
    private static object GetValue( FieldInfo field, object source, Dictionary<object, object> map )
    {
        object result = field.Get( source );
        object clone;
        if( map.TryGetValue( result, out clone ) )
        {
            return clone;
        }
        bool follow = result != null && result.GetType().IsClass && result.GetType() != typeof(string);
        return follow ? result.DeepClone( map ) : result;
    }
