    IEnumerable<T> result;
    Type type = typeof (T);
    //this is so hacky - the issue is that the Projector below uses Expression.Convert, which is a bottleneck
    //it's about 10x slower than our ToEnumerable. Our ToEnumerable, however, stumbles on Anon types and groupings
    //since it doesn't know how to instantiate them (I tried - not smart enough). So we do some trickery here.
        if (type.Name.Contains("AnonymousType") || type.Name.StartsWith("Grouping`") || type.FullName.StartsWith("System.")) {
        var reader = _provider.ExecuteReader(cmd);
        result = Project(reader, query.Projector);
        } else
        {
            using (var reader = _provider.ExecuteReader(cmd))
            {
                //use our reader stuff
                //thanks to Pascal LaCroix for the help here...
                var resultType = typeof (T);
                if (resultType.IsValueType)
                {
                    result = reader.ToEnumerableValueType<T>();
                }
                else
                {
                    result = reader.ToEnumerable<T>();
                }
            }
        }
        return result;
