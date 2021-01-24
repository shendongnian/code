    public void AddObject(object obj) {
        Type type;
        do {
            type = obj.GetType();
            if (!objs.ContainsKey(type) {
                objs[type] = new List<object>();
            }
            objs[type] = obj;
            if(type == typeof(object)) break;
            type = type.BaseType;
        } while(true);
    }
