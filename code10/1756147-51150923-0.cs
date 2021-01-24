        private readonly ISettings source;
        private string GetSerialized(string name)
        {
            var prop = this.source.GetType().GetProperty(name);
            foreach (object attr in prop.GetCustomAttributes(true))
            {
                var val_attr = attr as DefaultSettingValueAttribute;
                if (val_attr != null)
                    return val_attr.Value;
            }
            return null;
        }
        private T GetDefault<T>([CallerMemberName] string name = null)
        {
            string s = GetSerialized(name);
            if (s == null)
                return default(T);
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
            return (T)tc.ConvertFromString(s);
        }
