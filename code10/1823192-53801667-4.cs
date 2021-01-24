    public static class WithExtension
    {
        public static void With(this object o, object values)
        {
            var props = TypeDescriptor.GetProperties(values);
            var sourceProps = TypeDescriptor.GetProperties(o);
            foreach (PropertyDescriptor p in props)
            {
                sourceProps[p.Name].SetValue(o, p.GetValue(values));
            }
        }
    }
