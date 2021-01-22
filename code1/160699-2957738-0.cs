    public T DeserializeFromXML<T>(string path) {
       return (T)DeserializeFromXML(typeof(T), path);
    }
    public object DeserializeFromXML(Type type, string path) {
        //TODO: real code
    }
