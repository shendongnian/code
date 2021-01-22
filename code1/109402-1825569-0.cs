    public static bool TryFindType(string typeName, out Type t) {
        lock (typeCache) {
            if (!typeCache.TryGetValue(typeName, out t)) {
                foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies()) {
                    t = a.GetType(typeName);
                    if (t != null)
                        break;
                }
                typeCache[typeName] = t; // perhaps null
            }
        }
        return t != null;
    }
