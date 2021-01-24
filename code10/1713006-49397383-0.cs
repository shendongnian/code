    static class ExtensionMethods
    {
        public static T GetTypedValue<T>(this FieldInfo This, object instance)
        {
            return (T)This.GetValue(instance);
        }
    }
