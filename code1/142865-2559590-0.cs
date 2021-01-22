    Type[] GetTypes(Type itemType) {
        List<Type> tList = new List<Type>();
        Assembly[] appAssemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (Assembly a in appAssemblies) {
            Module[] mod = a.GetModules();
            foreach (Module m in mod) {
                Type[] types = m.GetTypes();
                foreach (Type t in types) {
                    try {
                        if (t == itemType || t.IsSubclassOf(itemType)) {
                            tList.Add(t);
                        }
                    }
                    catch (NullReferenceException) { }
                }
            }
        }
        return tList.ToArray();
    }
