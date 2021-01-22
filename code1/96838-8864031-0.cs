    Type tColl = typeof(ICollection<>);
    foreach (PropertyInfo p in (o.GetType()).GetProperties()) {
    	Type t = p.PropertyType;
    	if (t.IsGenericType && tColl.IsAssignableFrom(t.GetGenericTypeDefinition()) ||
    		t.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == tColl)) {
    		Console.WriteLine(p.Name + " IS an ICollection<>");
    	} else {
    		Console.WriteLine(p.Name + " is NOT an ICollection<>");
    	}
    }
