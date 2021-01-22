    static T ConvertToObject<T>(string str) {
     Type type = typeof(T);
     if (type == typeof(string)) return (T)(object)val;
     if (type == typeof(int)) return (T)(object)int.Parse(val);
     if (type.InSubclassOf(typeof(CodeObject))) return ConvertCodeObjectToObject((CodeObject)val);
    }
    
    static T ConvertCodeObjectToObject<T>(string str) where T: CodeObject {
     return Codes.Get<T>(val);
    }
