    public static void Copy(object source, object target)
        {
            foreach (System.Reflection.PropertyInfo pi in source.GetType().GetProperties())
            {
                System.Reflection.PropertyInfo tpi = target.GetType().GetProperty(pi.Name);
                if (tpi != null && tpi.PropertyType.IsAssignableFrom(pi.PropertyType))
                {
                    tpi.SetValue(target, pi.GetValue(source, null), null);
                }
            }
        }
