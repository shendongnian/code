    if (me != null)
    {
        try {
            if (mi is PropertyInfo && ((PropertyInfo)mi).PropertyType.IsAssignableFrom(me.Type))
                bindings.Add(Expression.Bind(mi, me));
            else if (mi is FieldInfo && ((FieldInfo)mi).FieldType.IsAssignableFrom(me.Type))
                bindings.Add(Expression.Bind(mi, me));
        } catch {
            //this is only here until I rewrite this whole thing
        }
    }
