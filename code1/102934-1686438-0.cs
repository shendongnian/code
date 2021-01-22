    class Manager {
        Dictionary<string, WeakReference> refs =
            new Dictionary<string, WeakReference>();
        public object this[string key] {
            get {
                WeakReference wr;
                if (refs.TryGetValue(key, out wr)) {
                    if(wr.IsAlive) return wr.Target;
                    refs.Remove(key);
                }
                return null;
            }
            set {
                refs[key] = new WeakReference(value);
            }
        }
    }
    static void Main() {
        Manager mgr = new Manager();
        var obj = new byte[1024];
        mgr["abc"] = obj;
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        Console.WriteLine(mgr["abc"] != null); // true (still ref'd by "obj")
        obj = null;
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        Console.WriteLine(mgr["abc"] != null); // false (no remaining refs)
    }
