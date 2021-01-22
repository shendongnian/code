    public class ObjectDumper
    {
        public static string Dump(object obj)
        {
            return new ObjectDumper().DumpObject(obj);
        }
        StringBuilder _dumpBuilder = new StringBuilder();
        string DumpObject(object obj)
        {
            DumpObject(obj, 0);
            return _dumpBuilder.ToString();
        }
        void DumpObject(object obj, int nestingLevel = 0)
        {
            var nestingSpaces = "".PadLeft(nestingLevel * 4);
            if (obj == null)
            {
                _dumpBuilder.AppendFormat("{0}null\n", nestingSpaces);
            }
            else if (obj is string || obj.GetType().IsPrimitive)
            {
                _dumpBuilder.AppendFormat("{0}{1}\n", nestingSpaces, obj);
            }
            else if (ImplementsDictionary(obj.GetType()))
            {
                foreach (dynamic p in (dynamic)obj)
                {
                    _dumpBuilder.AppendFormat("{0}{1} ({2})\n", nestingSpaces, p.Key, p.Value != null ? p.Value.GetType() : "<null>");
                    DumpObject(p.Value, nestingLevel + 1);
                }
            }
            else if (obj is IEnumerable)
            {
                foreach (dynamic p in obj as IEnumerable)
                {
                    DumpObject(p, nestingLevel);
                }
            }
            else
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(obj);
                    _dumpBuilder.AppendFormat("{0}{1}={2}\n", nestingSpaces, name, value);
                }
            }
        }
        bool ImplementsDictionary(Type t)
        {
            return t.GetInterfaces().Any(i => i.Name.Contains("IDictionary"));
        }
    }
