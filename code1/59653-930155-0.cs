    string TypeNameLower<T>(T obj) {
       return typeof(T).Name.ToLower();
    }
    
    string TypeNameLower(object obj) {
       if (obj != null) { return obj.GetType().Name.ToLower(); }
       else { return null; }
    }
    
    string s = null;
    TypeNameLower(s); // goes to the generic version
