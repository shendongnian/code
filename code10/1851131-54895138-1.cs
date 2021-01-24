    public static Dictionary<Type, object> PropertDicts { get; } = new Dictionary<Type, object>();
    public static void SetProperty<T>(string name, T value)
    {
        Dictionary<string, T> typedDict;
        if (PropertDicts.TryGetValue(typeof(T), out object dict)) {
            typedDict = (Dictionary<string, T>)dict;
        } else {
            typedDict = new Dictionary<string, T>();
            PropertDicts.Add(typeof(T), typedDict);
        }
        typedDict[name] = value;
    }
    public static T GetProperty<T>(string name)
    {
        if (PropertDicts.TryGetValue(typeof(T), out object dict)) {
            var typedDict = (Dictionary<string, T>)dict;
            if (typedDict.TryGetValue(name, out T value)) {
                return value;
            }
        }
        return default(T);
    }
