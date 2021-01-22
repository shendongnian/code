    public Func<T,bool> MakeTest<T,V>(string name, string op, V value)
    {
        Func<T,V> getter;
        var f = typeof(T).GetField(name);
        if (f != null)		
        {
            if (!typeof(V).IsAssignableFrom(f.FieldType))
                throw new ArgumentException(name +" incompatible with "+ typeof(V));
            getter= x => (V)f.GetValue(x);
        }
        else 
        {
            var p = typeof(T).GetProperty(name);
            if (p == null)		
                throw new ArgumentException("No "+ name +" on "+ typeof(T));
            if (!typeof(V).IsAssignableFrom(p.PropertyType))
                throw new ArgumentException(name +" incompatible with "+ typeof(V));
            getter= x => (V)p.GetValue(x, null);
        }
        switch (op)
        {
            case "==":
                return t => EqualityComparer<V>.Default.Equals(getter(t), value);
            case "!=":
                return t => !EqualityComparer<V>.Default.Equals(getter(t), value);
            case ">":
                return t => Comparer<V>.Default.Compare(getter(t), value) > 0;
            // fill in the banks as you need to
            default:
                throw new ArgumentException("unrecognised operator '"+ op +"'");
        }
    }	
