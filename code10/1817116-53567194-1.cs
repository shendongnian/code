    public static bool TrySet_SingletonInstance<T>(this T c) where T : Component
    {
        //Find a static field of type T defined in class T 
        var target = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public).SingleOrDefault(p => p.FieldType == typeof(T));
        //Not found; must not be static or public, or doesn't exist. Return false.
        if (target == null) return false;
        //Get existing value
        var oldValue = (T)target.GetValue(null);
        //Old value isn't null. Return false.
        if (oldValue != null) return false;
        //Set the value
        target.SetValue(null, c);
        //Success!
        return true;
    }
