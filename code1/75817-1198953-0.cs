        public void Update(MyObject o)
        {
            MyObject copyObject = ...
            Type type = o.GetType();
            while (type != null)
            {
                UpdateForType(type, o, copyObject);
                type = type.BaseType;
            }
        }
        private static void UpdateForType(Type type, MyObject source, MyObject destination)
        {
            FieldInfo[] myObjectFields = type.GetFields(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo fi in myObjectFields)
            {
                fi.SetValue(destination, fi.GetValue(source));
            }
        }
