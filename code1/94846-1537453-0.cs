    static class ControlAssign
    {
        public static void Assign(Control target, object source, PropertyInfo prop)
        {
            Setters[prop.PropertyType](prop, source, target);
        }
        static ControlAssign()
        {
            Setters[typeof(string)] = (prop, src, target) =>
            {
                ((TextBox)target).Text =
                    (string)prop.GetValue(src, null);
            };
            Setters[typeof(bool?)] = (prop, src, target) =>
            {
                ((CheckBox)target).Checked =
                    (bool)prop.GetValue(src, null);
            };
            Setters[typeof(bool)] = (prop, src, target) =>
            {
                ((CheckBox)target).Checked =
                    (bool)prop.GetValue(src, null);
            };
        }
        public delegate void Action<T, U, V>(T t, U u, V v);
        readonly static Dictionary<Type, Action<PropertyInfo, object, Control>> Setters = new Dictionary<Type, Action<PropertyInfo, object, Control>>();
    }
