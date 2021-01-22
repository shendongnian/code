    enum MyProperties {
        Prop1,
        Prop2
    }
    
    // ...
    
    static class PropertyProvider {
        static Hashtable<MyProperties, Object> cache = new Hashtable<MyProperties, Object>();
        static Object getProperty(MyProperties prop) {
            if (!cache.ContainsKey(prop)) {
                cache.add(prop, "SOMETHING");
            }
    
            return cache[prop];
        }
    }
